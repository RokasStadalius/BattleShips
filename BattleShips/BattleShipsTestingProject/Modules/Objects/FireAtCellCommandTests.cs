using BattleShips.Models;
using Moq;
using Xunit;

namespace BattleShipsTestingProject.Modules.Objects
{
    public class FireAtCellCommandTests
    {
        private FireAtCellCommand _command;
        private Mock<IShipFactory> shipFactoryMock;
        private Mock<Field> fieldMock;
        private GameFacade gameFacade;

        public FireAtCellCommandTests()
        {
            shipFactoryMock = new Mock<IShipFactory>();
            fieldMock = new Mock<Field>("Test Field", 10, 10);
            gameFacade = new GameFacade(fieldMock.Object, shipFactoryMock.Object);
        }

        [Fact]
        public void Execute_ShouldCallFireAtCell_OnGameFacade()
        {
            // Arrange
            int row = 2;
            int col = 3;
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            _command = new FireAtCellCommand(gameFacade, row, col, 0);

            // Act
            _command.Execute();

            // Assert
            gameFacade.FireAtCell(row, col, 0);
        }

        [Fact]
        public void Execute_ShouldNotThrowException_WhenCalled()
        {
            // Arrange
            int row = 2;
            int col = 3;
            var field = new Field("Test Field", 10, 10);
            var ship = new Battleship(1, 1, "Test Battleship") { IsVertical = false };
            gameFacade.availableShips.Add(ship);
            _command = new FireAtCellCommand(gameFacade, row, col, 0);

            gameFacade.FireAtCell(row, col, 0);

            // Act & Assert
            var exception = Record.Exception(() => _command.Execute());
            Assert.Null(exception);
        }

        [Fact]
        public void Undo_ShouldCallUndoFireAt_OnGameFacade()
        {
            // Arrange
            int row = 2;
            int col = 3;
            int shipIndex = 1;
            _command = new FireAtCellCommand(gameFacade, row, col, shipIndex);

            // Act
            _command.Undo();

            // Assert
            gameFacade.UndoFireAt(row, col);
        }

        [Fact]
        public void Undo_ShouldNotThrowException_WhenCalled()
        {
            // Arrange
            int row = 2;
            int col = 3;
            int shipIndex = 1;
            _command = new FireAtCellCommand(gameFacade, row, col, shipIndex);

            gameFacade.UndoFireAt(row, col);

            // Act & Assert
            var exception = Record.Exception(() => _command.Undo());
            Assert.Null(exception);
        }
    }
}

