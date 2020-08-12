using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block07PatientResultLotInfo : CobasIntegra400Base
    {
        private const string BlockCode = "07";

        public Line53OrderId OrderId { get; private set; }
        public Line56SampleName SampleName { get; private set; }
        public Line15AccessDateTime AccessDateTime { get; private set; }
        public Line16ResultIndexes ResultIndexes { get; private set; }
        public Line55TestId TestId { get; private set; }
        public Line11ReagentLotInfo ReagentLotInfo { get; private set; }
        public Line00ResultData ResultData { get; private set; }

        public Block07PatientResultLotInfo(List<string> data)
        {
            var line53 = data.FirstOrDefault(a => a.StartsWith("53"));
            var line56 = data.FirstOrDefault(a => a.StartsWith("56"));
            var line15 = data.FirstOrDefault(a => a.StartsWith("15"));
            var line16 = data.FirstOrDefault(a => a.StartsWith("16"));
            var line55 = data.FirstOrDefault(a => a.StartsWith("55"));
            var line11 = data.FirstOrDefault(a => a.StartsWith("11"));
            var line00 = data.FirstOrDefault(a => a.StartsWith("00"));

            OrderId = new Line53OrderId().Detect(line53);
            SampleName = new Line56SampleName().Detect(line56);
            AccessDateTime = new Line15AccessDateTime().Detect(line15);
            ResultIndexes = new Line16ResultIndexes().Detect(line16);
            TestId = new Line55TestId().Detect(line55);
            ReagentLotInfo = new Line11ReagentLotInfo().Detect(line11);
            ResultData = new Line00ResultData().Detect(line00);
        }
    }
}