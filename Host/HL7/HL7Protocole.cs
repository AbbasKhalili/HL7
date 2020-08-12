using System;
using System.Text;

namespace Host.HL7
{
    public class HL7Protocol
    {
        public string HandleMessage(string data)
        {
            string responseMessage = null;
            try
            {
                var message = new Message();
                message.DeSerializeMessage(data);

                // You can do what you want with the message here as per your application requirements.
                // For eg: read patient ID, patient last name, age etc.

                // Create a response message

                MainWindow._MainWindow.AppendText("-------------------------------");
                MainWindow._MainWindow.AppendText(message.SerializeMessage());
                MainWindow._MainWindow.AppendText("-------------------------------");



                responseMessage = CreateResponseMessage(message.MessageControlId());
            }
            catch (Exception ex)
            {
                MainWindow._MainWindow.AppendText(ex.Message);
            }
            return responseMessage;
        }

        private string CreateResponseMessage(string messageControlId)
        {
            var response = new Message();

            var msh = new Segment("MSH");
            msh.Field(2, "^~\\&");
            msh.Field(7, DateTime.Now.ToString("yyyyMMddhhmmsszzz"));
            msh.Field(9, "ACK");
            msh.Field(10, Guid.NewGuid().ToString());
            msh.Field(11, "P");
            msh.Field(12, "2.5.1");
            response.Add(msh);

            var msa = new Segment("MSA");
            msa.Field(1, "AA");
            msa.Field(2, messageControlId);
            response.Add(msa);

            var frame = new StringBuilder();
            frame.Append((char)0x0b);
            frame.Append(response.SerializeMessage());
            frame.Append((char)0x1c);
            frame.Append((char)0x0d);

            return frame.ToString();
        }
    }
}
