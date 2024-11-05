using Bunit;
using Moq;
using Blazored.Toast.Services;
using BattleShips.Models;
using Microsoft.JSInterop;
using Xunit;
using BattleShips.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class FieldBuildingComponentTests : TestContext
    {

        private Mock<IToastService> mockToastService;

        public FieldBuildingComponentTests()
        {
            // Initialize the mock service and register it
            mockToastService = new Mock<IToastService>();
            Services.AddSingleton<IToastService>(mockToastService.Object);
        }
        [Fact]
        public void Component_ShouldRenderCorrectly_ForPlayer1()
        {
            // Arrange
            var mockJSRuntime = Mock.Of<IJSRuntime>();
            var mockToastService = Mock.Of<IToastService>();

            Services.AddSingleton(mockJSRuntime);
            Services.AddSingleton(mockToastService);

            var fieldModel = new Field("Test Field", 10, 10);

            // Act
            var component = RenderComponent<FieldBuildingComponent>(parameters => parameters
                .Add(p => p.PlayerID, 1)
                .Add(p => p.FieldModel, fieldModel)
            );

            // Assert
            Assert.Contains("German Destroyer", component.Markup);
            Assert.Contains("German Submarine", component.Markup);
        }

    }
}
