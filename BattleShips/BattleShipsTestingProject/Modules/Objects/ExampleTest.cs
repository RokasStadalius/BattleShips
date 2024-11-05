using BattleShips.Models;

namespace BattleShipsTestingProject.Modules.Object
{
    public class ExampleTest
    {
        [Fact]
        public void MakeShallowCopy_ShouldCreateNewInstance()
        {
            // Arrange
            Ship originalShip = new Battleship(1, 1, "TestShip");

            // Act
            Ship copiedShip = originalShip.MakeShalowCopy();

            // Assert: Check that the copied ship is a new instance
            Assert.NotSame(originalShip, copiedShip);
        }
    }
}