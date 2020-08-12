using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line07ABSSampleCheck : BaseLineCode<Line07ABSSampleCheck>
    {
        public float AbsorbencyValue1 { get; private set; }
        public float AbsorbencyValue2 { get; private set; }
        public float AbsorbencyValue3 { get; private set; }
        public float AbsorbencyValue4 { get; private set; }
        public float AbsorbencyValue5 { get; private set; }
        public float AbsorbencyValue6 { get; private set; }

        public Line07ABSSampleCheck() : base("07")
        {
        }

        protected override Line07ABSSampleCheck Assign(List<string> data)
        {
            AbsorbencyValue1 = data[1].ToFloat();
            AbsorbencyValue2 = data[2].ToFloat();
            AbsorbencyValue3 = data.Count >= 4 ? data[3].ToFloat() : 0;
            AbsorbencyValue4 = data.Count >= 5 ? data[4].ToFloat() : 0;
            AbsorbencyValue5 = data.Count >= 6 ? data[5].ToFloat() : 0;
            AbsorbencyValue6 = data.Count >= 7 ? data[6].ToFloat() : 0;
            return this;
        }
    }
}