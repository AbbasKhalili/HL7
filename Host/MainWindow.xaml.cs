using System;
using System.Windows;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Documents;
using Host.Cobas;
using Host.Cobas.Blocks;
using Host.Tcp;
using Host.Tools;

namespace Host
{
    public partial class MainWindow : Window
    {
        private SerialPort _serialPort;

        private CobasIntegra400 _cobas;
        private Publisher _publisher;

        public static MainWindow _MainWindow;



        public MainWindow()
        {
            InitializeComponent();
            _MainWindow = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                _serialPort = new SerialPort(portnametextbox.Text)
                {
                    BaudRate = int.Parse(text1.Text),
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    DataBits = int.Parse(ComboDataBit.Text),
                    Handshake = Handshake.None,
                    Encoding = Encoding.ASCII
                };

                _cobas = new CobasIntegra400(txtDeviceName.Text);

                //var res = "\u0001\n14 COBAS INTEGRA400 04\n\u0002\n53 31z19908        14/07/2020 SER\n55  75\n00  8.442746E+01 mg/dl    0   0   0   0  0.000000E+00\n\u0003\n1\n565\n\u0004\n";
                //var result = _cobas.Response(res);
                //RichText1.AppendText(result);

                _serialPort.DataReceived += DataReceived;

                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                AppendText("Serial port is open.\r\n");
            }
            catch (Exception ex)
            {
                AppendText("Error opening serial port :: " + ex.Message + "\r\n");
            }
        }

        void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = _serialPort.ReadLine();
            var ttt = _cobas.Response(data);
            Application.Current.Dispatcher.Invoke(() => {
                AppendText(" >> " + data);
                AppendText(" >> " + ttt);
                AppendText("******************************************************************");
            });
        }

        private void WriteOnPort(string data)
        {
            try
            {
                _serialPort.Write(data);
                AppendText(data);
                AppendText("------------------------------------------------------------------");
            }
            catch (Exception e)
            {
                AppendText($"Exception : {e.Message}");
            }
        }

        public void AppendText(string text)
        {
            Application.Current.Dispatcher.Invoke(() => {
                RichText1.AppendText($"{text}\n");
                RichText1.ScrollToEnd();
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = _cobas.DefinePatient(patientid.Text, DateTime.Now, "M", "no more information");
            WriteOnPort(data);
        }
        
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var data = _cobas.ResultRequest(ResultRequestCombo.Text);
            WriteOnPort(data);
        }

        private void bu_10_07_Click(object sender, RoutedEventArgs e)
        {
            var testList = tests.Text.Split(",").Select(a => a.ToInt()).ToList();
            var data = _cobas.NewSampleOrder(patientid1.Text, orderNumber.Text, DateTime.Now,
                RackNumber.Text.ToInt(), TubeNumber.Text.ToInt(), OrderPriority.Active, "sampleName",
                testList, "no more info");
            WriteOnPort(data);
        }

        private void cmdIdle_Click(object sender, RoutedEventArgs e)
        {
            var data = _cobas.Idle();
            WriteOnPort(data);
        }

        private void AddTestToSample_Click(object sender, RoutedEventArgs e)
        {
            var testList = tests2.Text.Split(",").Select(a => a.ToInt()).ToList();
            var data = _cobas.AddTestToSampleOrder(patientId2.Text, orderNumber2.Text, testList);
            WriteOnPort(data);
        }

        private void colibrationrequest_Click(object sender, RoutedEventArgs e)
        {
            var testList = tests3.Text.Split(",").Select(a => a.ToInt()).ToList();
            var data = _cobas.CalibrationControlOrder(SpecialOrderType.ControlOrder, "I", testList);
            WriteOnPort(data);
        }

        private void protocolVersion_Click(object sender, RoutedEventArgs e)
        {
            var data = _cobas.ProtocolVersionRequest();
            WriteOnPort(data);
        }

        private void systemStatus_Click(object sender, RoutedEventArgs e)
        {
            var data = _cobas.SystemStatusRequest();
            WriteOnPort(data);
        }

        private void ConnectToMindray_Click(object sender, RoutedEventArgs e)
        {
            var ip = txtIp.Text.Split(".").Select(a=>a.ToByte()).ToArray();
            var port = txtPort.Text.ToInt();
            var address = new IPAddress(ip);
            var endPoint = new IPEndPoint(address, port);

            var command = $"{(char)0x0b}MSH|^~\\&|Mindray||||||ORU^R01|7|P|2.3.1|\nPID|||M1015_00010||John^||20091112|M|||^^^^|||{(char)0x1c}{(char)0x0d}";
            txtCommand.AppendText(command);

            try
            {
                var subscriber = new Subscriber(endPoint);
                var listenerThread = new Thread(subscriber.Listen);
                listenerThread.Start();
                AppendText($"Listener Start.");
                
                _publisher = new Publisher(ip, port);

                
                

                var senderThread = new Thread(_publisher.Send);
                senderThread.Start();
                AppendText($"Sender Start.");
            }
            catch (Exception ex)
            {
                AppendText($"Exception : {ex.Message}");
            }
        }

        private void cmdSend_Click(object sender, RoutedEventArgs e)
        {
            var richText = new TextRange(txtCommand.Document.ContentStart, txtCommand.Document.ContentEnd).Text;
            _publisher.Send(richText);
        }

        private void ComboDataBit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
