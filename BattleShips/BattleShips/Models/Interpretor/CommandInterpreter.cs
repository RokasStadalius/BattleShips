using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Interpretor
{
    public class CommandInterpreter
    {
        private readonly List<IExpression> _commands = new List<IExpression>();

        public void AddCommand(IExpression command)
        {
            _commands.Add(command);
        }

        public void Interpret(Field FieldModel, FieldCell cellInitial, Ship selectedShip, RoomService roomService, IToastService toastService, bool Enabled, string RoomID)
        {
            foreach (var command in _commands)
            {
                command.Interpret(FieldModel, cellInitial, selectedShip, roomService, toastService, Enabled, RoomID);
            }
        }
    }
}
