using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace BattleShipsCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class BattleShipsNullCheckAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "BattleShipsNullCheck";

        private static readonly LocalizableString Title = "Parameter null-check missing";
        private static readonly LocalizableString MessageFormat = "Parameter '{0}' should be checked for null before use.";
        private static readonly LocalizableString Description = "Ensure parameters are checked for null before usage to prevent null reference exceptions.";
        private const string Category = "Reliability";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
        {
            var methodDeclaration = (MethodDeclarationSyntax)context.Node;

            // Check if the method contains parameters
            if (!methodDeclaration.ParameterList.Parameters.Any())
                return;

            foreach (var parameter in methodDeclaration.ParameterList.Parameters)
            {
                var parameterName = parameter.Identifier.Text;

                // Look for the parameter usage in the method body
                var body = methodDeclaration.Body;
                if (body == null) // Ignore methods with no body (e.g., interface or abstract methods)
                    continue;

                var parameterUsed = body.DescendantNodes()
                    .OfType<IdentifierNameSyntax>()
                    .Any(identifier => identifier.Identifier.Text == parameterName);

                if (parameterUsed)
                {
                    // Check if there is a null check for this parameter
                    var nullCheckExists = body.DescendantNodes()
                        .OfType<BinaryExpressionSyntax>()
                        .Any(binary =>
                            binary.IsKind(SyntaxKind.NotEqualsExpression) &&
                            binary.Left is IdentifierNameSyntax left &&
                            left.Identifier.Text == parameterName &&
                            binary.Right.IsKind(SyntaxKind.NullLiteralExpression));

                    if (!nullCheckExists)
                    {
                        // Report diagnostic
                        var diagnostic = Diagnostic.Create(
                            Rule, parameter.GetLocation(), parameterName);
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }
    }
}