namespace BattleShips.Models
{
    public class RoomStateBuilingMaps : IRoomState
    {
        string IRoomState.StateName => "Statomas žemėlapis";
        string IRoomState.StateBadgeClass => "badge-info";
        public void OnEnter(Room room)
        {
        }

        public void Handle(Room room)
        {
            if (room.IsGameStarted)
            {
                room.SetRoomState(new RopomStateGameStarted());
            }
        }
    }
}
