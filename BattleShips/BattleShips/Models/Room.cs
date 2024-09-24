namespace BattleShips.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int CurrentPlayerCount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
