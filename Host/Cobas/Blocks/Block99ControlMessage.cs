using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block99ControlMessage : CobasIntegra400Base
    {
        private const string BlockCode = "99";

        public Line99GeneralErrorCode GeneralErrorCode  { get; private set; }

        public Block99ControlMessage(List<string> data)
        {
            var line99 = data.FirstOrDefault(a => a.StartsWith("99"));

            GeneralErrorCode = new Line99GeneralErrorCode().Detect(line99);
        }
    }
}