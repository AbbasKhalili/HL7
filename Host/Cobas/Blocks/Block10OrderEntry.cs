using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block10OrderEntry : BlockCodeBase
    {
        private const string BlockCode = "10";
        
        public Line50PatientId PatientId { get; private set; }
        public Line53OrderId OrderId { get; private set; }
        public Line54OrderInformation OrderInformation { get; private set; }
        public Line56SampleName SampleName { get; private set; }
        public List<Line55TestId> TestIds { get; private set; }
        public Line52SpecialOrderSelection SpecialOrderSelection { get; private set; }


        public Block10OrderEntry(string deviceName) : base(deviceName, BlockCode)
        {
            
        }

        protected override string Build() => $"{PatientId.Build()}{OrderId.Build()}" +
                                             $"{OrderInformation.Build()}{SampleName.Build()}" +
                                             $"{GetTests()}";


        public Block10OrderEntry Create(Line50PatientId patientId,Line53OrderId orderId,Line54OrderInformation orderInfo,Line56SampleName sampleName, List<Line55TestId> testIds)
        {
            PatientId = patientId;
            OrderId = orderId;
            OrderInformation = orderInfo;
            SampleName = sampleName;
            TestIds = testIds;
            return this;
        }

        public string AddTestToExistingOrder(Line50PatientId patientId, Line53OrderId orderId, List<Line55TestId> testIds)
        {
            PatientId = patientId;
            OrderId = orderId;
            TestIds = testIds;
            return MakePacket($"{PatientId.Build()}{OrderId.Build()}{GetTests()}");
        }

        public string CalibrationControlOrder(Line52SpecialOrderSelection selection, List<Line55TestId> testIds)
        {
            SpecialOrderSelection = selection;
            TestIds = testIds;
            return MakePacket($"{SpecialOrderSelection.Build()}{GetTests()}");
        }

        private string GetTests() => string.Join("", TestIds.Select(a => a.Build()).ToList());
    }
}