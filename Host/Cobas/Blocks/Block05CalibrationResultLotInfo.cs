using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block05CalibrationResultLotInfo : CobasIntegra400Base
    {
        private const string BlockCode = "05";

        public Line55TestId TestId { get; private set; }
        public Line15AccessDateTime AccessDateTime { get; private set; }
        public Line16ResultIndexes ResultIndexes { get; private set; }
        public Line03StandardRates StandardRates { get; private set; }
        public Line04CalibrateCurve CalibrateCurve { get; private set; }
        public Line13CalibratorLotInfo CalibratorLotInfo { get; private set; }
        public Line11ReagentLotInfo ReagentLotInfo { get; private set; }
        public Line00ResultData ResultData { get; private set; }
        public Line07ABSSampleCheck ABSSampleCheck { get; private set; }

        public Block05CalibrationResultLotInfo(List<string> data)
        {
            var line55 = data.FirstOrDefault(a => a.StartsWith("55"));
            var line15 = data.FirstOrDefault(a => a.StartsWith("15"));
            var line16 = data.FirstOrDefault(a => a.StartsWith("16"));
            var line03 = data.FirstOrDefault(a => a.StartsWith("03"));
            var line04 = data.FirstOrDefault(a => a.StartsWith("04"));
            var line13 = data.FirstOrDefault(a => a.StartsWith("13"));
            var line11 = data.FirstOrDefault(a => a.StartsWith("11"));
            var line00 = data.FirstOrDefault(a => a.StartsWith("00"));
            var line07 = data.FirstOrDefault(a => a.StartsWith("07"));

            TestId = new Line55TestId().Detect(line55);
            AccessDateTime = new Line15AccessDateTime().Detect(line15);
            ResultIndexes = new Line16ResultIndexes().Detect(line16);
            StandardRates = new Line03StandardRates().Detect(line03);
            CalibrateCurve = new Line04CalibrateCurve().Detect(line04);
            CalibratorLotInfo = new Line13CalibratorLotInfo().Detect(line13);
            ReagentLotInfo = new Line11ReagentLotInfo().Detect(line11);
            ResultData = new Line00ResultData().Detect(line00);
            ABSSampleCheck = new Line07ABSSampleCheck().Detect(line07);
        }
    }
}