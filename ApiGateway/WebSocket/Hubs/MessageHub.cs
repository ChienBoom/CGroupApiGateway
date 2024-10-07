using Microsoft.AspNetCore.SignalR;

namespace WebSocket.Hubs
{
    public class MessageHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(user, message);
        }
    }
}
