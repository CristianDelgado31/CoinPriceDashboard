using Microsoft.AspNetCore.SignalR;
using StockPriceDashboard.API.Models;

namespace CoinPriceDashboard.API.Hubs
{
    public class CoinHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"El usuario: {Context.ConnectionId} se ha conectado!");
            await Clients.All.SendAsync("ReceiveMessage", $"Received the message: Another connection has been added.");

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"El usuario {Context.ConnectionId} se ha desconectado");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendData(List<CoinData> data)
        {
            Console.WriteLine("Actualizando datos en tiempo real!");
            await Clients.All.SendAsync("ReceiveData", data);
        }

        public async Task JoinGroup(string groupName)
        {
            Console.WriteLine($"Un usuario se ha conectado al grupo {groupName}");
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
