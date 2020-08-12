namespace Host.Cobas.Blocks
{
    public class Block09ResultRequest : BlockCodeBase
    {
        private const string BlockCode = "09";
        public Block09ResultRequest(string deviceName) : base(deviceName, BlockCode)
        {
        }
        private string Builder(string code) => MakePacket(code);
        public string Code1001() => Builder("10_01");
        public string Code1002() => Builder("10_02");
        public string Code1003() => Builder("10_03");
        public string Code1004() => Builder("10_04");
        public string Code1005() => Builder("10_05");
        public string Code1006() => Builder("10_06");
        public string Code1007() => Builder("10_07");
        public string Code1008() => Builder("10_08");
        public string Code1009() => Builder("10_09");
        public string Code1011() => Builder("10_11");
        public string Code1017() => Builder("10_17");
        public string Code1018() => Builder("10_18");
        public string Code1019() => Builder("10_19");

        protected override string Build() => "";
    }
}