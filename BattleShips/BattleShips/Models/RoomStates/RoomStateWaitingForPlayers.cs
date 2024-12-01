namespace BattleShips.Models
{
    public class RoomStateWaitingForPlayers : IRoomState
    {
        string IRoomState.StateName => "Laukiama žaidėjų";
        string IRoomState.StateBadgeClass => "badge-warning";
        public void OnEnter(Room room)
        {
        }

        public void Handle(Room room)
        {
            if (room.CurrentPlayerCount == room.MaxPlayerCount)
            {
                room.SetRoomState(new RoomStateBuilingMaps());
            }
        }
    }
}
