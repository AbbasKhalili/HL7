using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line50PatientId : BaseLineCode<Line50PatientId>
    {
        public string PatientId { get; private set; }

        public Line50PatientId() : base("50") { }

        public static Line50PatientId Create(string patientId)
        {
            return new Line50PatientId()
            {
                PatientId = patientId
            };
        }

        public string Build() => $"{LineCode}_{PatientId.ToFixLength(15)}{LF}";


        protected override Line50PatientId Assign(List<string> data)
        {
            PatientId = data[1];
            return this;
        }
    }
}