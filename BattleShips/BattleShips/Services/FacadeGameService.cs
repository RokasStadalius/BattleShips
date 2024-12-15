using BattleShips.Models;
using BattleShips.Models.Handlers;
using Blazored.Toast.Services;

namespace BattleShips.Services
{
    public class FacadeGameService
    {
        private readonly GameFacade _gameFacade;
        private readonly CommandInvoker _invoker;
        private IActionHandler _actionHandlerChain;
        public FacadeGameService(Field field, IShipFactory factory)
        {
            _gameFacade = new GameFacade(field, factory);
            _invoker = new CommandInvoker();
            var fireAtCellHandler = new FireAtCellHandler();
            _actionHandlerChain = fireAtCellHandler;
        }

        public void ExecuteFireAction(FieldCell cell, Field fieldModel, RoomService roomService,
                                  IToastService toastService, bool enabled, Ship? selectedShip, string roomId)
        {
            _actionHandlerChain.Handle(cell, fieldModel, roomService, toastService, enabled, selectedShip, roomId);
        }

        public void InitializeGame()
        {
            _gameFacade.CreateAndAddShip("battleship", 1, 101, "Big-boomer");
            _gameFacade.CreateAndAddShip("submarine", 2, 102, "Under-waterer");
            

            var destroyer = new Destroyer(1, 1, "TestShip number 1");
            var submarine = new Submarine(2, 2, "TestShip number 2");
            var fleet = new Fleet();
            fleet.Add(destroyer);
            fleet.Add(submarine);
            var ships = new List<Ship>();
            ships.Add(destroyer);
            ships.Add(submarine);

            var visitor = new ShipTotalHPVisitor();

            foreach (var ship in ships)
            {
                ship.Accept(visitor);
            }
            

            fleet.DisplayDetails();
            Console.WriteLine($"Total Fleet Length: {fleet.GetLength()}");
            Console.WriteLine($"Total Hit Points: {visitor.TotalHitPoints}");
        }

        public void PlaceShip(int shipIndex, FieldCell startingCell)
        {
            ICommand command = new PlaceShipCommand(_gameFacade, shipIndex, startingCell);
            _invoker.ExecuteCommand(command);
        }

        public void FireAt(int row, int col, int shipIndex)
        {
            ICommand command = new FireAtCellCommand(_gameFacade, row, col, shipIndex);
            _invoker.ExecuteCommand(command);
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
