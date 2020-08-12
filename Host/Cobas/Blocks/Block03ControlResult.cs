using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block03ControlResult : CobasIntegra400Base
    {
        private const string BlockCode = "03";

        public Line55TestId TestId { get; private set; }
        public Line01ResultTime ResultTime { get; private set; }
        public Line02ControlId ControlId { get; private set; }
        public Line00ResultData ResultData { get; private set; }


        public Block03ControlResult(List<string> body)
        {
            var line55 = body.FirstOrDefault(a => a.StartsWith("55"));
            var line01 = body.FirstOrDefault(a => a.StartsWith("01"));
            var line02 = body.FirstOrDefault(a => a.StartsWith("02"));
            var line00 = body.FirstOrDefault(a => a.StartsWith("00"));

            TestId = new Line55TestId().Detect(line55);
            ResultTime = new Line01ResultTime().Detect(line01);
            ControlId = new Line02ControlId().Detect(line02);
            ResultData = new Line00ResultData().Detect(line00);
        }

    }
}