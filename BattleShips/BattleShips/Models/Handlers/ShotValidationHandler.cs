using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Handlers
{
    public class CellAlreadyShotHandler : AbstractActionHandler
    {
        public override void Handle(FieldCell cell, Field fieldModel, RoomService roomService,
                                    IToastService toastService, bool enabled, Ship? selectedShip, string roomId)
        {
            if (cell.IsShot)
            {
                toastService.ShowError("Šis laukas jau buvo atakuotas");
            }
            else
            {
                _nextHandler?.Handle(cell, fieldModel, roomService, toastService, enabled, selectedShip, roomId);
            }
        }
    }
}
