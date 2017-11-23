using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTCPCommunication
{
    public class ClientHandler //hier schlachten wir die server klasse aus und alles was für eine spezielle client sendung relevant ist tun wir rein hier
    {
        Socket clientSocket;
        byte[] buffer = new byte[256];

        public ClientHandler(Socket clientSocket)  // da wir in server.cs kein clientsocket haben müssen wir es rüber senden das geht über diesen konstruktor
        {
            this.clientSocket = clientSocket;
            //StartReceive();
            ThreadPool.QueueUserWorkItem(StartReceive, null);
        }

        internal void SendData(string message)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(message));
        }

        //Methiode zum daten empfangen da client und server ready
        public void StartReceive(object o)
        {
            int length;
            while (true)
            {
                length = clientSocket.Receive(buffer);

                String data = Encoding.ASCII.GetString(buffer, 0, length);
                Console.WriteLine(data);
            }
        }

    }
}
