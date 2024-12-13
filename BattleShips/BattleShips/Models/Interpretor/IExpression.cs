using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Interpretor
{
    public interface IExpression
    {
        void Interpret(Field FieldModel, FieldCell cellInitial, Ship selectedShip, RoomService roomService, IToastService toastService, bool Enabled, string RoomID);
    }
}
