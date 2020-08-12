using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Host.HL7;

namespace Host.Tcp
{
    public class Subscriber
    {
        private readonly Socket _listener;
        
        public Subscriber(IPEndPoint endPoint)
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(endPoint);
            Console.WriteLine("Listening to port {0}", endPoint);
            _listener.Listen(3);
        }

        public void Listen()
        {
            byte[] buffer;
            int count;
            string data;
            string tempData;
            string response;
            int start;
            int end;

            var handler = new HL7Protocol();

            try
            {
                while (true)
                {
                    buffer = new byte[4096];
                    var receiver = _listener.Accept();
                    while (true)
                    {
                        count = receiver.Receive(buffer);
                        data = Encoding.UTF8.GetString(buffer, 0, count);
                        
                        start = data.IndexOf((char)0x0b);
                        
                        if (start < 0) continue;

                        end = data.IndexOf((char)0x1c);
                        
                        if (end <= start) continue;

                        tempData = Encoding.UTF8.GetString(buffer, 4, count - 12);

                        response = handler.HandleMessage(tempData);

                        MainWindow._MainWindow.AppendText(response);

                        receiver.Send(Encoding.UTF8.GetBytes(response));
                        break;
                    }

                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();
                }
            }
            catch (SocketException ex)
            {
                MainWindow._MainWindow.AppendText($"Exception : {ex.Message}");
            }
        }
    }
}
