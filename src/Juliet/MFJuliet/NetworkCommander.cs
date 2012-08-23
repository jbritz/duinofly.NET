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
        private Socket _Socket;
        public NetworkCommander(string destinationAddress, int port)
        {
            var ip = IPAddress.Parse(destinationAddress);
            _EndPoint = new IPEndPoint(ip, port);
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Socket.Connect(_EndPoint);
        }

        public void SendCommand(string command)
        {
            try
            {
                _Socket.Send(Encoding.UTF8.GetBytes(command));
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }
    }
}
