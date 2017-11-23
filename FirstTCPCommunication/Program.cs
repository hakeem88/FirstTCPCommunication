using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTCPCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            ClientHandler ch = new ClientHandler();
            s.AcceptClients();       // wir bleiben im serversocket.accept stecken, wenn sich einer hin verbindet kommt man nicht mehr in die methode.. multithreading => mehrere aufrufe
            ch.SendData("Welcome");
            ch.StartReceive();
            Console.ReadLine();
        }
    }
}
