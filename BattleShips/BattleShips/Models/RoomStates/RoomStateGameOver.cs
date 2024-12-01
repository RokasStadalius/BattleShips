namespace BattleShips.Models
{
    public class RoomStateGameOver : IRoomState
    {
        string IRoomState.StateName => "Žaidimas baigtas";
        string IRoomState.StateBadgeClass => "badge-danger";

        public void OnEnter(Room room)
        {
            room.EndGame();
        }

        public void Handle(Room room)
        {
        }
    }
}
