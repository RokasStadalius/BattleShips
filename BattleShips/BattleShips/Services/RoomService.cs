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
            RefreshRoomList();
        }

        public void RefreshRoomList()
        {
            _hubContext.Clients.All.SendAsync("ReceiveRoomUpdate");
        }
        public void StartRoomGame(Room room = null)
        {
            _hubContext.Clients.All.SendAsync("GameStarted");
        }
    }
}
