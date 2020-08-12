using System.Collections.Generic;
using System.Security.Cryptography;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line04CalibrateCurve : BaseLineCode<Line04CalibrateCurve>
    {
        public float CorrectionFactor { get; private set; }
        public float CorrectionOffset { get; private set; }
        public float CorrectionParameter1 { get; private set; }
        public float CorrectionParameter2 { get; private set; }
        public float CorrectionParameter3 { get; private set; }
        public float CorrectionParameter4 { get; private set; }
        public float CorrectionParameter5 { get; private set; }

        public Line04CalibrateCurve() : base("04")
        {
        }

        protected override Line04CalibrateCurve Assign(List<string> data)
        {
            CorrectionFactor = data[1].ToFloat();
            CorrectionOffset = data[2].ToFloat();
            CorrectionParameter1 = data[3].ToFloat();
            CorrectionParameter2 = data.Count >= 5 ? data[4].ToFloat() : 0;
            CorrectionParameter3 = data.Count >= 6 ? data[5].ToFloat() : 0;
            CorrectionParameter4 = data.Count >= 7 ? data[6].ToFloat() : 0;
            CorrectionParameter5 = data.Count >= 8 ? data[7].ToFloat() : 0;
            return this;
        }
    }
}