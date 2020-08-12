using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line56SampleName : BaseLineCode<Line56SampleName>
    {
        public string SampleName { get; private set; }

        public Line56SampleName() : base("56"){}

        public static Line56SampleName Create(string sampleName)
        {
            return new Line56SampleName {SampleName = sampleName};
        }

        public string Build() => $"{LineCode}_{SampleName.ToFixLength(50)}{LF}";


        protected override Line56SampleName Assign(List<string> data)
        {
            SampleName = data[1];
            return this;
        }
    }
}