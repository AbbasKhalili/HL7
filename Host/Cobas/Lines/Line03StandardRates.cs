using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line03StandardRates : BaseLineCode<Line03StandardRates>
    {
        public StandardType StandardType { get; private set; }
        public string StandardRate1 { get; private set; }
        public string StandardRate2 { get; private set; }
        public string StandardRate3 { get; private set; }
        public string StandardRate4 { get; private set; }
        public string StandardRate5 { get; private set; }

        public Line03StandardRates() : base("03")
        {
        }

        protected override Line03StandardRates Assign(List<string> data)
        {
            StandardType = new StandardType
            {
                Type = (StandardTypeEnum)data[1][0], 
                Value = data[2].ToFloat()
            };
            StandardRate1 = data.Count >= 4 ? data[3] : "";
            StandardRate2 = data.Count >= 5 ? data[4] : "";
            StandardRate3 = data.Count >= 6 ? data[5] : "";
            StandardRate4 = data.Count >= 7 ? data[6] : "";
            StandardRate5 = data.Count >= 8 ? data[7] : "";
            return this;
        }
    }

    public class StandardType
    {
        public StandardTypeEnum Type { get; set; }
        public float Value { get; set; }

    }
    public enum StandardTypeEnum
    {
        Calibration = 'C',
        Correction = 'O',
        Cal_CorAntigenExcessRate = 'A'
    }
}