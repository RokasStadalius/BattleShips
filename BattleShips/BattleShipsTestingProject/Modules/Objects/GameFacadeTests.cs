using BattleShips.Models;
using Moq;
using Xunit;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class GameFacadeTests
    {
        private Mock<IShipFactory> shipFactoryMock;
        private Mock<Field> fieldMock;
        private GameFacade gameFacade;

        public GameFacadeTests()
        {
            shipFactoryMock = new Mock<IShipFactory>();
            fieldMock = new Mock<Field>("Test Field", 10, 10);
            gameFacade = new GameFacade(fieldMock.Object, shipFactoryMock.Object);
        }

        [Fact]
        public void CreateAndAddShip_ShouldAddShip_WhenValidTypeIsProvided()
        {
            // Arrange
            string shipType = "battleship";
            int shipID = 1;
            int shipTypeID = 1;
            string shipName = "Test Battleship";
            gameFacade = new GameFacade(fieldMock.Object, shipFactoryMock.Object);

            var expectedShip = new Battleship(shipID, shipTypeID, shipName);
            shipFactoryMock.Setup(sf => sf.CreateBattleship(shipID, shipTypeID, shipName)).Returns(expectedShip);

            // Act
            gameFacade.CreateAndAddShip(shipType, shipID, shipTypeID, shipName);

            // Assert
            Assert.Contains(expectedShip, gameFacade.availableShips);
        }

        [Fact]
        public void CreateAndAddShip_ShouldThrowException_WhenInvalidShipTypeIsProvided()
        {
            // Arrange
            string shipType = "invalidShipType";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                gameFacade.CreateAndAddShip(shipType, 1, 1, "Invalid Ship"));
            Assert.Equal("Invalid type of the ship provided.", exception.Message);
        }

        [Fact]
        public void PlaceShip_ShouldPlaceShip_WhenPlacementIsValid()
        {
            // Arrange
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            var startingCell = new FieldCell(0, 0);

            bool canPlace = field.CanPlaceShip(ship, startingCell);

            // Assert
            Assert.True(canPlace);
            gameFacade.PlaceShip(0, startingCell);
        }

        [Fact]
        public void PlaceShip_ShouldNotPlaceShip_WhenPlacementIsInvalid()
        {
            // Arrange
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            var startingCell = new FieldCell(0, 0);
            field.PlaceShipOnMap(ship, startingCell);
            bool result = field.CanPlaceShip(ship, startingCell);


            // Assert
            Assert.False(result);
            Assert.Throws<InvalidOperationException>(() => field.PlaceShipOnMap(ship, startingCell));
        }

        [Fact]
        public void FireAtCell_ShouldNotThrowException_WhenCellIsValid()
        {
            // Arrange
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship");
            gameFacade.availableShips.Add(ship);

            //test will fail if an exception is thrown
            gameFacade.FireAtCell(0, 0, 0);
        }

        [Fact]
        public void RemoveShip_ShouldRemoveShip_WhenValidShipIndexProvided()
        {
            // Arrange
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            var startCell = new FieldCell(0, 0);

            // Act
            gameFacade.RemoveShip(0, startCell);

            // Assert
            Assert.DoesNotContain(ship, gameFacade.availableShips);
        }

        [Fact]
        public void RemoveShip_ShouldThrowException_WhenInvalidShipIndexProvided()
        {
            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
                gameFacade.RemoveShip(0, new FieldCell(0, 0)));
        }

        [Fact]
        public void UndoFireAt_ShouldUndoFire_WhenCellWasShot()
        {
            // Arrange
            var row = 0;
            var col = 0;
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            var targetCell = new FieldCell(row, col);

            gameFacade.FireAtCell(row, col, 0);
            // Act
            gameFacade.UndoFireAt(row, col);

            // Assert
            Assert.False(targetCell.IsShot);
        }

        [Fact]
        public void IsGameOver_ShouldReturnTrue_WhenNoShipsLeft()
        {
            // Arrange
            var field = new Field("Test Field", 10, 10);
            bool noShips = field.IsOutOfShips();
            bool result = gameFacade.IsGameOver();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGameOver_ShouldReturnFalse_WhenShipsAreAvailable()
        {
            // Arrange
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            var startingCell = new FieldCell(0, 0);
            field.PlaceShipOnMap(ship, startingCell);

            bool result = field.IsOutOfShips();

            // Assert
            Assert.False(result);
        }
    }
}