using System.Net.Sockets;
using Engine.Resources;

namespace Engine.Network
{
    public class Server:NetworkApi
    {
        public Server()
        {
            lisner = new TcpListener(Parameters.IpAddress,Parameters.port);
            lisner.Start(1);
            WaitForConnection();
        }

        private async void WaitForConnection()
        {
            Client = await lisner.AcceptTcpClientAsync();
            Init(Client.GetStream());
        }

        public TcpListener lisner { get; }
        public TcpClient Client { get; set; }
       
    }
}
