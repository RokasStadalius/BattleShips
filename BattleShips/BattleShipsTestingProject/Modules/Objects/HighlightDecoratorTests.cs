using BattleShips.Models;
using Xunit;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class HighlightDecoratorTests
    {
        [Fact]
        public void GetCellColorState_ShouldReturnHighlightColor_WhenCellIsNotShotAndEmpty()
        {
            // Arrange
            var cell = new FieldCell(0, 0);
            var ship = new Battleship(1, 1, "Test Ship") { ShipTypeID = 1 }; // Type ID 1 corresponds to green highlight
            var decorator = new HighlightDecorator(cell, ship);

            // Act
            var colorState = decorator.GetCellColorState(showShips: false);

            // Assert
            Assert.Equal("rgba(0, 255, 0, 0.5)", colorState);
        }

        [Fact]
        public void GetCellColorState_ShouldReturnBaseColor_WhenCellIsShot()
        {
            // Arrange
            var cell = new FieldCell(0, 0) { IsShot = true };
            var ship = new Battleship(1, 1, "Test Ship") { ShipTypeID = 2 };
            var decorator = new HighlightDecorator(cell, ship);

            // Act
            var colorState = decorator.GetCellColorState(showShips: false);

            // Assert
            Assert.NotEqual("rgba(255, 0, 0, 0.5)", colorState); // The highlight color should not be returned
            Assert.Equal(cell.GetCellColorState(false), colorState); // Verify it returns the base color state
        }

        [Fact]
        public void GetCellColorState_ShouldReturnBaseColor_WhenCellContainsShip()
        {
            // Arrange
            var cell = new FieldCell(0, 0) { CellShip = new Battleship(1, 1, "Test Ship") };
            var ship = new Battleship(2, 2, "Test Dragged Ship") { ShipTypeID = 3 };
            var decorator = new HighlightDecorator(cell, ship);

            // Act
            var colorState = decorator.GetCellColorState(showShips: false);

            // Assert
            Assert.NotEqual("rgba(0, 0, 255, 0.5)", colorState); // The highlight color should not be returned
            Assert.Equal(cell.GetCellColorState(false), colorState); // Verify it returns the base color state
        }

        [Theory]
        [InlineData(1, "rgba(0, 255, 0, 0.5)")] // Green for type ID 1
        [InlineData(2, "rgba(255, 0, 0, 0.5)")] // Red for type ID 2
        [InlineData(3, "rgba(0, 0, 255, 0.5)")] // Blue for type ID 3
        [InlineData(4, "rgba(255, 255, 0, 0.5)")] // Yellow for type ID 4
        [InlineData(99, "rgba(255, 255, 255, 0.5)")] // Default color for unknown type IDs
        public void HighlightColor_ShouldMatchExpectedColor(int shipTypeId, string expectedColor)
        {
            // Arrange
            var cell = new FieldCell(0, 0);
            var ship = new Battleship(1, shipTypeId, "Test Ship");
            var decorator = new HighlightDecorator(cell, ship);

            // Act
            var colorState = decorator.GetCellColorState(showShips: false);

            // Assert
            Assert.Equal(expectedColor, colorState);
        }
    }

}
