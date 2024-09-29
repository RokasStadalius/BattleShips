using BattleShips.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace BattleShips.Services
{
    public class RoomService
    {
        private List<Room> Rooms = new List<Room>();
        private readonly IHubContext<RoomHub> _hubContext;
        private HubConnection? hubConnection;

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

        public async Task<bool> JoinRoom(string roomId, User user,string connectionId)
        {
            var room = GetRoomById(roomId);
            if (room != null && !room.IsFull)
            {
                room.AddPlayer(user);

                await _hubContext.Groups.AddToGroupAsync(connectionId, room.RoomId);

                await _hubContext.Clients.Group(room.RoomId).SendAsync("ReceiveRoomUpdate");


                return true;
            }
            return false;
        }
        public async Task LeaveRoom(string roomId, string connectionId)
        {
            var room = GetRoomById(roomId);
            if (room != null)
            {
                await _hubContext.Groups.RemoveFromGroupAsync(connectionId, room.RoomId);

                await _hubContext.Clients.Group(room.RoomId).SendAsync("ReceiveRoomUpdate");
            }
        }
    }
}
