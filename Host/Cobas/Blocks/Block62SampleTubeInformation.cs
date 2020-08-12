using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block62SampleTubeInformation : CobasIntegra400Base
    {
        private const string BlockCode = "62";

        public Line42TubeInformation TubeInformation { get; private set; }

        public Block62SampleTubeInformation(List<string> data)
        {
            var line42 = data.FirstOrDefault(a => a.StartsWith("42"));

            TubeInformation = new Line42TubeInformation().Detect(line42);
        }
    }
}