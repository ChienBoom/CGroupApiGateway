using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using WebSocket.Models;

namespace WebSocket.Hubs
{
    public class MessageHub: Hub
    {
        private static ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            await Clients.Client(connectionId).SendAsync("RequireClientName", connectionId);
            Console.WriteLine("ConnectionId: " +  connectionId);
            GetClients();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connections.TryRemove(Context.ConnectionId, out _);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUser(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", "Server", message);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task ConfirmClientName(ClientInfo client)
        {
            _connections.TryAdd(client.ConnectionId, client.Name);
            Console.WriteLine("ConnectionId: " + client.ConnectionId + " - ClientName: " + client.Name);
        }

        public void GetClients()
        {
            foreach (var kvp in _connections)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                Console.WriteLine($"Key: {key}, Value: {value}");
            }
        }

    }
}
