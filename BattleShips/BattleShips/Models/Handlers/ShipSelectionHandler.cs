using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Handlers
{
    public class ShipSelectionHandler : AbstractActionHandler
    {
        public override void Handle(FieldCell cell, Field fieldModel, RoomService roomService,
                                    IToastService toastService, bool enabled, Ship? selectedShip, string roomId)
        {
            if (selectedShip == null)
            {
                toastService.ShowError("Pasirinkite laivą");
            }
            else
            {
                _nextHandler?.Handle(cell, fieldModel, roomService, toastService, enabled, selectedShip, roomId);
            }
        }
    }
}
