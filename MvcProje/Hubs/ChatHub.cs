using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR;
namespace MvcProje.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string user, string message)
        {
            // Tüm bağlantılara mesaj gönder
            Clients.All.receiveMessage(user, message);
        }
    }
}