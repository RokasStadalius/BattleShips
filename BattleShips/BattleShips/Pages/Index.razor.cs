using Microsoft.Extensions.Diagnostics.HealthChecks;
using BattleShips.Models;

namespace BattleShips.Pages
{
    public partial class Index
    {
        public List<Room> GetAllRoom()
        {
            List<Room> list = new List<Room>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(
                    new Room
                    {
                        ID = i,
                        RoomName = "testas " + i.ToString(),
                        MaxPlayerCount = 3,
                        CurrentPlayerCount = rnd.Next(0,4),
                        DateCreated = DateTime.Now
                    }
                    );
            }
            return list;
        }
    }
}
