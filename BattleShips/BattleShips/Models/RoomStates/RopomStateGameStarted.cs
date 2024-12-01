namespace BattleShips.Models
{
    public class RopomStateGameStarted : IRoomState
    {
        string IRoomState.StateName => "Žaidimas pradėtas";
        string IRoomState.StateBadgeClass => "badge-success";
        public void OnEnter(Room room)
        {
            room.StartGame();
        }

        public void Handle(Room room)
        {
            if (room.IsGameOver == true)
            {
                room.SetRoomState(new RoomStateGameOver());
            }
        }
    }
}
