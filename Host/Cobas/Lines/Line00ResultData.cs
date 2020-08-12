using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line00ResultData : BaseLineCode<Line00ResultData>
    {
        public float Result { get; private set; }
        public string Unit { get; private set; }
        public byte FlagX { get; private set; }
        public byte FlagS { get; private set; }
        public byte FlagCALC { get; private set; }
        public byte FlagQC { get; private set; }
        public float RangeValueToFlag { get; private set; }
        public float RangeLimit { get; private set; }

        public Line00ResultData() : base("00") { }

        protected override Line00ResultData Assign(List<string> data)
        {
            Result = data[1].ToFloat();
            Unit = data[2];
            FlagX = data[3].ToByte();
            FlagS = data[4].ToByte();
            FlagCALC = data[5].ToByte();
            FlagQC = data[6].ToByte();
            RangeValueToFlag = data.Count >= 8 ? data[7].ToFloat() : 0;
            RangeLimit = data.Count >= 9 ? data[8].ToFloat() : 0;
            return this;
        }
    }
}