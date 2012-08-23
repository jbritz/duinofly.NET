using System;
using System.Net.Sockets;

namespace Juliet
{
    public class TCPCommandClient
    {
        public TCPCommandClient(TcpClient tcpClient, byte[] buffer)
        {
            if (tcpClient == null) throw new ArgumentNullException("tcpClient");
            if (buffer == null) throw new ArgumentNullException("buffer");
            this.TcpClient = tcpClient;
            this.Buffer = buffer;
        }

        /// <summary>
        /// Gets the TCP Client
        /// </summary>
        public TcpClient TcpClient { get; private set; }

        /// <summary>
        /// Gets the Buffer.
        /// </summary>
        public byte[] Buffer { get; private set; }

        /// <summary>
        /// Gets the network stream
        /// </summary>
        public NetworkStream NetworkStream { get { return TcpClient.GetStream(); } }
    }
}
