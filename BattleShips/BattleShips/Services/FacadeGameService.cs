using BattleShips.Models;

namespace BattleShips.Services
{
    public class FacadeGameService
    {
        private readonly GameFacade _gameFacade;
        private readonly CommandInvoker _invoker;
        public FacadeGameService(Field field, IShipFactory factory)
        {
            _gameFacade = new GameFacade(field, factory);
            _invoker = new CommandInvoker();
        }

        public void InitializeGame()
        {
            _gameFacade.CreateAndAddShip("battleship", 1, 101, "Big-boomer");
            _gameFacade.CreateAndAddShip("submarine", 2, 102, "Under-waterer");
        }

        public void PlaceShip(int shipIndex, FieldCell startingCell)
        {
            ICommand command = new PlaceShipCommand(_gameFacade, shipIndex, startingCell);
            _invoker.ExecuteCommand(command);
            //return _gameFacade.PlaceShip(shipIndex, startingCell);
        }

        public void FireAt(int row, int col, int shipIndex)
        {
            ICommand command = new FireAtCellCommand(_gameFacade, row, col, shipIndex);
            _invoker.ExecuteCommand(command);
            //if (shipIndex < 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(shipIndex));
            //}

            //_gameFacade.FireAtCell(row, col, shipIndex);
        }

        public void Undo()
        {
            _invoker.Undo();
        }

        public void RemoveShip(int shipIndex, FieldCell startingCell) 
        {
            if (shipIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(shipIndex));
            }

            _gameFacade.RemoveShip(shipIndex, startingCell);
        }

        public void UndoFireAt(int row, int col)
        {
            _gameFacade.UndoFireAt(row, col);
        }

        public bool IsGameOver()
        {
            return _gameFacade.IsGameOver();
        }
    }
}
