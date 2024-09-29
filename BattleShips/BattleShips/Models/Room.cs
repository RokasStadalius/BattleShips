using System.Numerics;

namespace BattleShips.Models
{
    public class Room
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
        public int MaxPlayerCount { get; set; } = 2;
        public int CurrentPlayerCount => Players.Count;
        public List<User> Players { get; set; } = new List<User>();

        public bool IsGameStarted = false;
        public bool IsFull => Players.Count >= MaxPlayerCount;

        public Room(string roomName)
        {
            RoomId = Guid.NewGuid().ToString();
            RoomName = roomName;
            IsGameStarted = false;
            DateCreated = DateTime.Now;
        }

        public bool AddPlayer(User user)
        {
            if (!IsFull && Players.All(p => p.UserId != user.UserId))
            {
                Players.Add(user);
                return true;
            }
            return false;
        }
    }
}
