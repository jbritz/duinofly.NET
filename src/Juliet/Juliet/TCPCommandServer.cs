using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Juliet
{
    public class TCPCommandServer
    {
        private  TcpListener _TcpListener;
        private List<TCPCommandClient> _Clients = new List<TCPCommandClient>();

        public delegate void OnNewCommandHandler(string command);
        public event OnNewCommandHandler OnNewCommandRecieved;
        public Encoding Encoding { get; set; }
        public TCPCommandServer(string address, int port)
        {
            var ip = IPAddress.Parse(address);
            _TcpListener = new TcpListener(ip, port);
            this.Encoding = Encoding.Default;
        }

        /// <summary>
        /// Starts the TCP Server listening for new clients.
        /// </summary>
        public void Start()
        {
            this._TcpListener.Start();
            this._TcpListener.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
        }

        /// <summary>
        /// Stops the TCP Server listening for new clients and disconnects
        /// any currently connected clients.
        /// </summary>
        public void Stop()
        {
            this._TcpListener.Stop();
            lock (this._Clients)
            {
                foreach (TCPCommandClient client in this._Clients)
                {
                    client.TcpClient.Client.Disconnect(false);
                }
                this._Clients.Clear();
            }
        }

        /// <summary>
        /// Call-back for the accept TCP client operation.
        /// </summary>
        /// <param name="result">The async result object</param>
        private void AcceptTcpClientCallback(IAsyncResult result)
        {
            TcpClient tcpClient = _TcpListener.EndAcceptTcpClient(result);
            var buffer = new byte[tcpClient.ReceiveBufferSize];
            var client = new TCPCommandClient(tcpClient, buffer);
            lock (this._Clients)
            {
                this._Clients.Add(client);
            }
            NetworkStream networkStream = client.NetworkStream;
            networkStream.BeginRead(client.Buffer, 0, client.Buffer.Length, ReadCallback, client);
            _TcpListener.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
        }

        /// <summary>
        /// Call-back for the read operation.
        /// </summary>
        /// <param name="result">The async result object</param>
        private void ReadCallback(IAsyncResult result)
        {
            var client = result.AsyncState as TCPCommandClient;
            if (client == null) return;
            NetworkStream networkStream = client.NetworkStream;
            int read = networkStream.EndRead(result);
            if (read == 0)
            {
                lock (this._Clients)
                {
                    this._Clients.Remove(client);
                    return;
                }
            }

            try
            {
                string data = this.Encoding.GetString(client.Buffer, 0, read);

                //Send data to listeners
                RaiseOnCommandRecieved(data);

            }
            catch (Exception ex)
            {
                
                throw;
            }

            
            //Start listening for new events
            networkStream.BeginRead(client.Buffer, 0, client.Buffer.Length, ReadCallback, client);
        }

        /// <summary>
        /// Writes a string to a given TCP Client
        /// </summary>
        /// <param name="tcpClient">The client to write to</param>
        /// <param name="data">The string to send.</param>
        public void Write(TcpClient tcpClient, string data)
        {
            byte[] bytes = this.Encoding.GetBytes(data);
            Write(tcpClient, bytes);
        }

        /// <summary>
        /// Writes a string to all clients connected.
        /// </summary>
        /// <param name="data">The string to send.</param>
        public void Write(string data)
        {
            foreach (TCPCommandClient client in this._Clients)
            {
                Write(client.TcpClient, data);
            }
        }

        /// <summary>
        /// Writes a byte array to all clients connected.
        /// </summary>
        /// <param name="bytes">The bytes to send.</param>
        public void Write(byte[] bytes)
        {
            foreach (TCPCommandClient client in this._Clients)
            {
                Write(client.TcpClient, bytes);
            }
        }

        /// <summary>
        /// Writes a byte array to a given TCP Client
        /// </summary>
        /// <param name="tcpClient">The client to write to</param>
        /// <param name="bytes">The bytes to send</param>
        public void Write(TcpClient tcpClient, byte[] bytes)
        {
            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.BeginWrite(bytes, 0, bytes.Length, WriteCallback, tcpClient);
        }

        /// <summary>
        /// Call-back for the write operation.
        /// </summary>
        /// <param name="result">The async result object</param>
        private void WriteCallback(IAsyncResult result)
        {
            var tcpClient = result.AsyncState as TcpClient;
            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.EndWrite(result);
        }

        private void RaiseOnCommandRecieved(string command)
        {
            if (OnNewCommandRecieved != null)
            {
                OnNewCommandRecieved(command);
            }
        }
    }
}
