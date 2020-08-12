using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block61SlotConfiguration : CobasIntegra400Base
    {
        private const string BlockCode = "61";

        public Line41SlotState SlotState { get; private set; }
        
        public Block61SlotConfiguration(List<string> data)
        {
            var line41 = data.FirstOrDefault(a => a.StartsWith("41"));

            SlotState = new Line41SlotState().Detect(line41);
        }
    }
}