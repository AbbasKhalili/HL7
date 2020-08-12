using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block04PatientResults : CobasIntegra400Base
    {
        private const string BlockCode = "04";

        public Line53OrderId OrderId { get; private set; }
        public Line56SampleName SampleName { get; private set; }
        public Line55TestId TestId { get; private set; }
        public Line00ResultData ResultData { get; private set; }


        public Block04PatientResults(List<string> body)
        {
            var line53 = body.FirstOrDefault(a => a.StartsWith("53"));
            var line56 = body.FirstOrDefault(a => a.StartsWith("56"));
            var line55 = body.FirstOrDefault(a => a.StartsWith("55"));
            var line00 = body.FirstOrDefault(a => a.StartsWith("00"));

            OrderId = new Line53OrderId().Detect(line53);
            SampleName = new Line56SampleName().Detect(line56);
            TestId = new Line55TestId().Detect(line55);
            ResultData = new Line00ResultData().Detect(line00);
        }
    }
}