using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        const int PORT_NO = 3000;
        const string SERVER_IP = "192.168.1.65";

        static void Main(string[] args)
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Server Started...");
            listener.Start();

            TcpClient client = listener.AcceptTcpClient();

            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            string datareceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("received : " + datareceived);

            Console.WriteLine("Hoşgeldiniz.");
            nwStream.Write(buffer, 0, bytesRead);

            client.Close();
            listener.Stop();

            Console.ReadLine();
        }
    }
}