using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block42PatientModification : BlockCodeBase
    {
        private const string BlockCode = "42";


        private Line50PatientId PatientId { get; set; }
        private Line51PatientInfo PatientInfo { get; set; }

        public Block42PatientModification(string deviceName) : base(deviceName, BlockCode)
        {
        }

        public Block42PatientModification Create(Line50PatientId patientId, Line51PatientInfo patientInfo)
        {
            PatientId = patientId;
            PatientInfo = patientInfo;
            return this;
        }

        protected override string Build()
        {
            return $"{PatientId.Build()}{PatientInfo.Build()}";
        }
    }
}