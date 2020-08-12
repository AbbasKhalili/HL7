using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block19OrderManipulationResponse : CobasIntegra400Base
    {
        private const string BlockCode = "19";

        public Line96ErrorCode ErrorCode { get; private set; }
        public Line50PatientId PatientId { get; private set; }
        public Line53OrderId OrderId { get; private set; }
        public Line54OrderInformation OrderInformation { get; private set; }
        public Line55TestId TestId { get; private set; }
        public Line52SpecialOrderSelection SpecialOrderSelection { get; private set; }


        public Block19OrderManipulationResponse(List<string> data)
        {
            var line96 = data.FirstOrDefault(a => a.StartsWith("96"));
            var line50 = data.FirstOrDefault(a => a.StartsWith("50"));
            var line53 = data.FirstOrDefault(a => a.StartsWith("53"));
            var line54 = data.FirstOrDefault(a => a.StartsWith("54"));
            var line55 = data.FirstOrDefault(a => a.StartsWith("55"));
            var line52 = data.FirstOrDefault(a => a.StartsWith("52"));

            ErrorCode = new Line96ErrorCode().Detect(line96);
            PatientId = new Line50PatientId().Detect(line50);
            OrderId = new Line53OrderId().Detect(line53);
            OrderInformation = new Line54OrderInformation().Detect(line54);
            TestId = new Line55TestId().Detect(line55);
            SpecialOrderSelection = new Line52SpecialOrderSelection().Detect(line52);
        }
    }
}