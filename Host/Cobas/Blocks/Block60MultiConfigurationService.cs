using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block60MultiConfigurationService : BlockCodeBase
    {
        private const string BlockCode = "60";


        private Line40ServiceSelection ServiceSelection { get; set; }
        

        public Block60MultiConfigurationService(string deviceName) : base(deviceName, BlockCode)
        {
        }

        public Block60MultiConfigurationService Create(Line40ServiceSelection serviceSelection)
        {
            ServiceSelection = serviceSelection;
            return this;
        }

        protected override string Build() => $"{ServiceSelection.Build()}";
    }
}