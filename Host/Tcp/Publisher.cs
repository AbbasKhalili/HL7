using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Host.Tcp
{
    public class Publisher
    {
        private Socket _sender;
        private readonly IPEndPoint _endPoint;

        private readonly List<string> _messagesQueue;

        public Publisher(byte[] localhost, int port)
        {
            _messagesQueue = new List<string>();
            var address = new IPAddress(localhost);
            _endPoint = new IPEndPoint(address, port);
        }

        public void Send(string message)
        {
            _messagesQueue.Add(message);
        }

        public void Send()
        {
            while (true)
            {
                try
                {
                    _sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _sender.Connect(_endPoint);
                    _sender.SendBufferSize = 4096;

                    try
                    {
                        for (var i = 0; i < _messagesQueue.Count; i++)
                        {
                            var data = Encoding.UTF8.GetBytes(_messagesQueue[i]);
                            _sender.Send(data);
                            MainWindow._MainWindow.AppendText(_messagesQueue[i]);

                            _messagesQueue.RemoveAt(i);
                        }
                    }
                    catch (SocketException ex)
                    {
                        MainWindow._MainWindow.AppendText($"Exception : {ex.Message}");
                    }
                    Thread.Sleep(5000);
                }
                catch (SocketException ex)
                {
                    MainWindow._MainWindow.AppendText($"Exception : {ex.Message}");
                }
                finally
                {
                    _sender.Close();
                }
            }
        }
    }
}