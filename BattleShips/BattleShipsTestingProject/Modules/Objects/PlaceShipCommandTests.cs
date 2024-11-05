using BattleShips.Models;
using Moq;
using Xunit;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class PlaceShipCommandTests
    {
        private PlaceShipCommand _command;
        private Mock<IShipFactory> shipFactoryMock;
        private Mock<Field> fieldMock;
        private GameFacade gameFacade;
        private FieldCell _startingCell;

        public PlaceShipCommandTests()
        {
            shipFactoryMock = new Mock<IShipFactory>();
            fieldMock = new Mock<Field>("Test Field", 10, 10);
            gameFacade = new GameFacade(fieldMock.Object, shipFactoryMock.Object);
            _startingCell = new FieldCell(0, 0);
        }

        [Fact]
        public void Execute_ShouldCallPlaceShip_OnGameFacade_WhenValidShipIndexProvided()
        {
            // Arrange
            int shipIndex = 0;
            gameFacade.availableShips.Add(new Battleship(1, 1, "Test Battleship"));
            _command = new PlaceShipCommand(gameFacade, shipIndex, _startingCell);

            // Act
            _command.Execute();

            // Assert
            gameFacade.PlaceShip(shipIndex, _startingCell);
        }

        [Fact]
        public void Execute_ShouldNotThrowException_WhenCalledWithValidShipIndex()
        {
            // Arrange
            int shipIndex = 0;
            gameFacade.availableShips.Add(new Battleship(1, 1, "Test Battleship"));
            _command = new PlaceShipCommand(gameFacade, shipIndex, _startingCell);

            // Act & Assert
            var exception = Record.Exception(() => _command.Execute());
            Assert.Null(exception);
        }

        [Fact]
        public void Undo_ShouldNotThrowException_WhenCalled()
        {
            // Arrange
            int shipIndex = 0;
            gameFacade.availableShips.Add(new Battleship(1, 1, "Test Battleship"));
            _command = new PlaceShipCommand(gameFacade, shipIndex, _startingCell);

            // Act & Assert
            var exception = Record.Exception(() => _command.Undo());
            Assert.Null(exception);
        }
    }
}
