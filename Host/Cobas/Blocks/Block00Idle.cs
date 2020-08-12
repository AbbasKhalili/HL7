using System.Collections.Generic;

namespace Host.Cobas.Blocks
{
    public class Block00Idle : BlockCodeBase
    {
        private const string BlockCode = "00";

        public Block00Idle(string deviceName) : base(deviceName, BlockCode)
        {
        }
        
        public Block00Idle(string deviceName, List<string> body) : this(deviceName)
        {
            
        }

        protected override string Build() => "";
    }
}