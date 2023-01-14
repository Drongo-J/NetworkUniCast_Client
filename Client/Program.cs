using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipAdress = IPAddress.Parse("10.2.11.43");
            var port = 27001;

            var ep = new IPEndPoint(ipAdress, port);

            try
            {
                socket.Connect(ep);
                if (socket.Connected)
                {
                    Console.WriteLine("Connected to server . . .");
                    while (true)
                    {
                        var msg = Console.ReadLine();
                        var bytes = Encoding.UTF8.GetBytes(msg);
                        socket.Send(bytes);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot connect to server . . .");
            }
        }
    }
}
