using BattleShips.Models.Handlers;
using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Interpretor
{
    public class CellClickExpression : IExpression
    {
        public string Target { get; }

        public CellClickExpression(string target)
        {
            Target = target;
        }

        public void Interpret(Field FieldModel, FieldCell cellInitial, Ship selectedShip, RoomService roomService, IToastService toastService, bool Enabled, string RoomID)
        {
            var shipSelectionHandler = new ShipSelectionHandler();
            var turnHandler = new TurnHandler();
            var cellAlreadyShotHandler = new CellAlreadyShotHandler();
            var fireAtCellHandler = new FireAtCellHandler();

            shipSelectionHandler.SetNext(turnHandler);
            turnHandler.SetNext(cellAlreadyShotHandler);
            cellAlreadyShotHandler.SetNext(fireAtCellHandler);

            shipSelectionHandler.Handle(cellInitial, FieldModel, roomService, toastService, Enabled, selectedShip, RoomID);
        }
    }
}
