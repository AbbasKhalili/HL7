using System.Collections.Generic;

namespace Host.Cobas.Lines
{
    public class Line16ResultIndexes : BaseLineCode<Line16ResultIndexes>
    {
        public string CalibrationIndex { get; private set; }
        public string ControlGroupIndex { get; private set; }
        public string SampleResultIndex { get; private set; }

        public Line16ResultIndexes() : base("16")
        {
        }

        protected override Line16ResultIndexes Assign(List<string> data)
        {
            CalibrationIndex = data[1];
            ControlGroupIndex = data[2];
            SampleResultIndex = data[3];
            return this;
        }
    }
}