using System;
using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block11OrderDeletion : BlockCodeBase
    {
        private const string BlockCode = "11";
        

        private Line53OrderId OrderId { get; set; }
        private List<Line55TestId> TestIds { get; set; }

        public Block11OrderDeletion(string deviceName) : base(deviceName, BlockCode)
        {
        }

        public string DeleteSampleOrder(Line53OrderId orderId)
        {
            OrderId = orderId;
            return MakePacket($"{OrderId.Build()}");
        }

        public string DeleteTestOrder(List<Line55TestId> testIds, Line53OrderId orderId)
        {
            TestIds = testIds;
            OrderId = orderId;
            return MakePacket($"{OrderId.Build()}{string.Join("", TestIds.Select(a => a.Build()).ToList())}");
        }

        protected override string Build() => $"{OrderId.Build()}";
    }
}