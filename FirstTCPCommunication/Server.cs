using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTCPCommunication
{
    class Server
    {
        Socket serverSocket;
        List<ClientHandler> clients = new List<ClientHandler>(); // hier lege ich alles aus clienthandler ab die liste mit den daten sachen die rüber zu server soll
  
        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Adressfamilie IP4 oder IP6, TCP etc..
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090)); // IP & PORT
            serverSocket.Listen(10); //Anzahl der Connections in der Queue 
            ThreadPool.QueueUserWorkItem(AcceptClients, null); //schaut ob platz frei ist.. falls ja übergibt es die methode damit sie auch gestartet wird also das accept siehe program.cs
        }

        public void AcceptClients(object o) //object o übergeben wir damit threadpool queeuserworkitem arbeiten kann weil er ein objekt brauch um die methode abzuarbeiten
        {
            while(true) { 
            clients.Add(new ClientHandler(serverSocket.Accept()));
            Console.WriteLine("Client accepted");
            }
        }               
    }
}
