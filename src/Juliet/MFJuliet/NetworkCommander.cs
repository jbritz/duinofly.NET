using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.SPOT;

namespace MFJuliet
{
    public class NetworkCommander
    {
        private IPEndPoint _EndPoint;
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
                socket.Close();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
