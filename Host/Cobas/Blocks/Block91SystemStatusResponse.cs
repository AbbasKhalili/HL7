using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block91SystemStatusResponse : CobasIntegra400Base
    {
        private const string BlockCode = "91";

        public Line97SystemStatus SystemStatus { get; private set; }

        public Block91SystemStatusResponse(List<string> data)
        {
            var line97 = data.FirstOrDefault(a => a.StartsWith("97"));

            SystemStatus = new Line97SystemStatus().Detect(line97);
        }
    }
}