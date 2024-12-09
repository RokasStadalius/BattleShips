using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Handlers
{
    public interface IActionHandler
    {
        IActionHandler SetNext(IActionHandler handler);
        void Handle(FieldCell cell, Field fieldModel, RoomService roomService,
                                IToastService toastService, bool enabled, Ship? selectedShip, string roomId);
    }
}
