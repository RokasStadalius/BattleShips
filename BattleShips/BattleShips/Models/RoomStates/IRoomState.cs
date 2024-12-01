namespace BattleShips.Models
{
    public interface IRoomState
    {
        public string StateName { get; }
        public string StateBadgeClass { get; }
        void OnEnter(Room room);
        void Handle(Room room);
    }
}
