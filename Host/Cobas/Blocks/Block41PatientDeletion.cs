using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public class Block41PatientDeletion : BlockCodeBase
    {
        private const string BlockCode = "41";
        
        private Line50PatientId PatientId { get; set; }
        

        public Block41PatientDeletion(string deviceName) : base(deviceName, BlockCode)
        {
        }

        public Block41PatientDeletion Create(Line50PatientId patientId)
        {
            PatientId = patientId;
            return this;
        }

        protected override string Build()
        {
            return $"{PatientId.Build()}";
        }
    }
}