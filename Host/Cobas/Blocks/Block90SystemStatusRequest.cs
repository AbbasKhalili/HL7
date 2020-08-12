namespace Host.Cobas.Blocks
{
    public class Block90SystemStatusRequest : BlockCodeBase
    {
        private const string BlockCode = "90";


        public Block90SystemStatusRequest(string deviceName) : base(deviceName, BlockCode)
        {
        }

        protected override string Build() => "";
    }
}