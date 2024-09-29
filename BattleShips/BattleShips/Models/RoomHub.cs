using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BattleShips.Models
{

    public class RoomHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
