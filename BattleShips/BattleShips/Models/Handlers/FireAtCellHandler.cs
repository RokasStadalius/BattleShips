using BattleShips.Services;
using Blazored.Toast.Services;

namespace BattleShips.Models.Handlers
{
    public class FireAtCellHandler : AbstractActionHandler
    {
        public override void Handle(FieldCell cell, Field fieldModel, RoomService roomService,
                                    IToastService toastService, bool enabled, Ship? selectedShip, string roomId)
        {
            fieldModel.FireAtCell(cell, selectedShip);

            if (fieldModel.IsOutOfShips())
            {
                roomService.EndGame("");
                toastService.ShowSuccess("All ships are destroyed!");
            }
            else
            {
                fieldModel.MissedShots++;
                roomService.ChangeTurn(roomId);
                Console.WriteLine("Nepataikei į laivą " + enabled);
            }
        }
    }

}
