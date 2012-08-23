using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Juliet
{
    public class CommandListener
    {
        private readonly Socket _Socket;
        private Timer _MessageTimer;

        public delegate void OnNewCommandHandler(string command);
        public event OnNewCommandHandler OnNewCommandRecieved;

        private IPEndPoint _EndPoint;

        public CommandListener(string destinationAddress, int port)
        {
            var ip = IPAddress.Parse(destinationAddress);
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _EndPoint = new IPEndPoint(ip, port);
            _Socket.Bind(_EndPoint);
            _Socket.Listen(1);

            _MessageTimer = new Timer(OnTimerTick, "", 1000, 1000);
        }

        private void OnTimerTick(object userState)
        {
            var message = GetCommand();
            if (message != "" && OnNewCommandRecieved != null)
            {
                OnNewCommandRecieved(message);
            }
        }

        static bool IsSocketConnected(Socket s)
        {
            bool canRead = s.Poll(1000, SelectMode.SelectRead);
            if (canRead && s.Available > 0)
            {
                return true;
            }

            return false;
        }

        public string GetCommand()
        {
            using (var readSocket = _Socket.Accept())
            {
                if (IsSocketConnected(readSocket))
                {
                    int availablebytes = readSocket.Available;
                    var buffer = new byte[availablebytes];
                    readSocket.Receive(buffer);
                    if (buffer.Length > 0)
                    {
                        return new String(Encoding.UTF8.GetChars(buffer));
                    }
                }
                return "";
            }
        }
    }
}
