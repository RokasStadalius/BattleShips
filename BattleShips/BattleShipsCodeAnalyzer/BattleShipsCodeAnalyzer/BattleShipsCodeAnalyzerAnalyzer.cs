using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace BattleShipsCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class BattleShipsCodeAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "BattleShipsCodeAnalyzer";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
        "DOC001", // Unique identifier for this rule
        "Public class is missing XML documentation",
        "Class '{0}' must have XML documentation",
        "Documentation",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            // Ensure the analyzer excludes generated code and runs concurrently
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            // Register a symbol action for class declarations
            context.RegisterSymbolAction(AnalyzeClass, SymbolKind.NamedType);
        }

        private static void AnalyzeClass(SymbolAnalysisContext context)
        {
            var classSymbol = (INamedTypeSymbol)context.Symbol;

            // Analyze only public classes
            if (classSymbol.DeclaredAccessibility == Accessibility.Public)
            {
                // Check if XML documentation is present
                if (string.IsNullOrWhiteSpace(classSymbol.GetDocumentationCommentXml()))
                {
                    var diagnostic = Diagnostic.Create(Rule, classSymbol.Locations[0], classSymbol.Name);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

    }
}
