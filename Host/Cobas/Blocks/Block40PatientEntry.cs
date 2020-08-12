using System;
using Host.Cobas.Lines;
using Host.Tools;

namespace Host.Cobas.Blocks
{
    public class Block40PatientEntry : BlockCodeBase
    {
        private const string BlockCode = "40";
        

        private Line50PatientId PatientId { get; set; }
        private Line51PatientInfo PatientInfo { get; set; }

        public Block40PatientEntry(string deviceName) : base(deviceName, BlockCode)
        {
        }

        public Block40PatientEntry Create(Line50PatientId patientId, Line51PatientInfo patientInfo)
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