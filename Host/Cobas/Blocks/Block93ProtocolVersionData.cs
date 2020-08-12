using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block93ProtocolVersionData : CobasIntegra400Base
    {
        private const string BlockCode = "93";

        public Line98ProtocolVersion ProtocolVersion { get; private set; }

        public Block93ProtocolVersionData(List<string> data)
        {
            var line98 = data.FirstOrDefault(a => a.StartsWith("98"));

            ProtocolVersion = new Line98ProtocolVersion().Detect(line98);
        }
    }
}