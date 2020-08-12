using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block49PatientManipulationResponse : CobasIntegra400Base
    {
        private const string BlockCode = "49";

        public Line96ErrorCode ErrorCode { get; private set; }
        public Line50PatientId PatientId { get; private set; }
        

        public Block49PatientManipulationResponse(List<string> data)
        {
            var line96 = data.FirstOrDefault(a => a.StartsWith("96"));
            var line50 = data.FirstOrDefault(a => a.StartsWith("50"));

            ErrorCode = new Line96ErrorCode().Detect(line96);
            PatientId = new Line50PatientId().Detect(line50);
        }
    }
}