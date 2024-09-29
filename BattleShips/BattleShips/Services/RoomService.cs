using BattleShips.Models;
using Microsoft.AspNetCore.SignalR;

namespace BattleShips.Services
{
    public class RoomService
    {
        private List<Room> Rooms = new List<Room>();
        private readonly IHubContext<RoomHub> _hubContext;

        public RoomService(IHubContext<RoomHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IEnumerable<Room> GetAllRooms() => Rooms;

        public Room GetRoomById(string roomId) => Rooms.FirstOrDefault(r => r.RoomId == roomId);

        public void CreateRoom(string roomName)
        {
            var room = new Room(roomName);
            Rooms.Add(room);
            _hubContext.Clients.All.SendAsync("ReceiveRoomUpdate");
        }

        public bool JoinRoom(string roomId, User user, string connectionId)
        {
            var room = GetRoomById(roomId);
            if (room != null && !room.IsFull)
            {
                _hubContext.Clients.All.SendAsync("ReceiveRoomUpdate");

                return true;
            }
            return false;
        }
        public void StartRoomGame(Room room)
        {
            _hubContext.Clients.All.SendAsync("GameStarted");
        }
    }
}
