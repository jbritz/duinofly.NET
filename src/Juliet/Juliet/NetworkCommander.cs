using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Juliet
{
    public class NetworkCommander
    {
        private IPEndPoint _EndPoint;
        private static ManualResetEvent _Block = new ManualResetEvent(false);
        public NetworkCommander(string destinationAddress, int port)
        {
            var ip = IPAddress.Parse(destinationAddress);
            _EndPoint = new IPEndPoint(ip, port);
        }

        public void SendCommand(string command)
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(_EndPoint);
                socket.Send(Encoding.UTF8.GetBytes(command));
                socket.Disconnect(true);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}