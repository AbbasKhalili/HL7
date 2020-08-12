using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block06ControlResultLotInfo : CobasIntegra400Base
    {
        private const string BlockCode = "06";

        public Line55TestId TestId { get; private set; }
        public Line15AccessDateTime AccessDateTime { get; private set; }
        public Line16ResultIndexes ResultIndexes { get; private set; }
        public Line11ReagentLotInfo ReagentLotInfo { get; private set; }
        public Line02ControlId ControlId { get; private set; }
        public Line12ControlLotInfo ControlLotInfo { get; private set; }
        public Line00ResultData ResultData { get; private set; }

        public Block06ControlResultLotInfo(List<string> data)
        {
            var line55 = data.FirstOrDefault(a => a.StartsWith("55"));
            var line15 = data.FirstOrDefault(a => a.StartsWith("15"));
            var line16 = data.FirstOrDefault(a => a.StartsWith("16"));
            var line11 = data.FirstOrDefault(a => a.StartsWith("11"));
            var line02 = data.FirstOrDefault(a => a.StartsWith("02"));
            var line12 = data.FirstOrDefault(a => a.StartsWith("12"));
            var line00 = data.FirstOrDefault(a => a.StartsWith("00"));
            

            TestId = new Line55TestId().Detect(line55);
            AccessDateTime = new Line15AccessDateTime().Detect(line15);
            ResultIndexes = new Line16ResultIndexes().Detect(line16);
            ReagentLotInfo = new Line11ReagentLotInfo().Detect(line11);
            ControlId = new Line02ControlId().Detect(line02);
            ControlLotInfo = new Line12ControlLotInfo().Detect(line12);
            ResultData = new Line00ResultData().Detect(line00);
        }
    }
}