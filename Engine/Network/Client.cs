using Engine.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Network
{
    public class Client:NetworkApi
    {
        public Client()
        {
            client = new TcpClient();
            
        }

        public TcpClient client { get; }

        public void Connect(IPAddress hostname)
        {
            client.Connect(hostname, Parameters.port);
            Init(client.GetStream());
        }
    }
}
