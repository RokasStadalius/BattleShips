using BattleShips.Services;
using Microsoft.AspNetCore.SignalR;

namespace BattleShips.Models
{
    public class RoomHub : Hub
    {
        private readonly RoomService _roomService;

        public RoomHub(RoomService roomService)
        {
            _roomService = roomService;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SetPlayerReady(string roomId, string userId)
        {
            var room = _roomService.GetRoomById(roomId);
            if (room != null)
            {
                room.SetPlayerReady(userId);
                await Clients.Group(roomId).SendAsync("GameStarted"); // Notify all clients
            }
        }

    }
}
