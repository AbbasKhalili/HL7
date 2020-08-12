namespace Host.Cobas.Blocks
{
    public class Block92ProtocolVersionRequest : BlockCodeBase
    {
        private const string BlockCode = "92";

        
        public Block92ProtocolVersionRequest(string deviceName) : base(deviceName, BlockCode)
        {
        }
        
        protected override string Build() => "";
    }
}