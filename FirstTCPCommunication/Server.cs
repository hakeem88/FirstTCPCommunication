using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstTCPCommunication
{
    class Server
    {
        Socket serverSocket;

        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Adressfamilie IP4 oder IP6, TCP etc..
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090)); // IP & PORT
            serverSocket.Listen(10); //Anzahl der Connections in der Queue 
        }
    }
}
