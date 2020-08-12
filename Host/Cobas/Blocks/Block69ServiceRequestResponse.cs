using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block69ServiceRequestResponse : CobasIntegra400Base
    {
        private const string BlockCode = "69";

        public Line96ErrorCode ErrorCode { get; private set; }

        public Block69ServiceRequestResponse(List<string> data)
        {
            var line96 = data.FirstOrDefault(a => a.StartsWith("96"));

            ErrorCode = new Line96ErrorCode().Detect(line96);
        }
    }
}