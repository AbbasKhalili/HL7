using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block08ResultRequestResponse : CobasIntegra400Base
    {
        private const string BlockCode = "08";

        public Line96ErrorCode ErrorCode { get; private set; }

        public Block08ResultRequestResponse(List<string> data)
        {
            var line96 = data.FirstOrDefault(a => a.StartsWith("96"));

            ErrorCode = new Line96ErrorCode().Detect(line96);
        }
    }
}