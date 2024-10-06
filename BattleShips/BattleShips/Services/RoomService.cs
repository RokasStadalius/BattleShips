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

        public void CreateRoomStandart(string roomName)
        {
            var room = new Room(roomName, "standart");
            Rooms.Add(room);
            RefreshRoomList();
        }

        public void CreateRoomMedium(string roomName)
        {
            var room = new Room(roomName, "medium");
            Rooms.Add(room);
            RefreshRoomList();
        }

        public void CreateRoomAdvanced(string roomName)
        {
            var room = new Room(roomName, "advanced");
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

        public void ChangeTurn(string roomID)
        {   
            var room = GetRoomById(roomID);
            room.ChangeTurn();
            _hubContext.Clients.All.SendAsync("ChangeTurn");
        }
        public void EndGame(string roomID)
        {
            _hubContext.Clients.All.SendAsync("EndGame");
        }
        public bool RemoveRoom(string roomID)
        {
            var room = GetRoomById(roomID);
            return Rooms.Remove(room);
        }


    }
}
