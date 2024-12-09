using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Handlers
{
    public abstract class AbstractActionHandler : IActionHandler
    {
        public IActionHandler _nextHandler;
        public virtual void Handle(FieldCell cell, Field fieldModel, RoomService roomService,
                                IToastService toastService, bool enabled, Ship? selectedShip, string roomId)
        {
            _nextHandler?.Handle(cell, fieldModel, roomService, toastService, enabled, selectedShip, roomId);
        }

        public IActionHandler SetNext(IActionHandler handler)
        {
            _nextHandler = handler;
            return handler;

        }
    }
}
