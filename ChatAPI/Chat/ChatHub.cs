using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatAPI.Chat
{
    public class ChatHub : Hub
    {

        public async Task SendToAll(string name, string message)
        {
            await Clients.All.SendAsync("sendToAlll", name, message);

        }
        public async Task Typing(string name, string message)
        {
            await Clients.Others.SendAsync("typing", name, message);

        }

        //             public void SendToAll(string name, string message)
        //  {
        //     Clients.All.SendAsync("sendToAll", name, message);
        //  }
    }
}