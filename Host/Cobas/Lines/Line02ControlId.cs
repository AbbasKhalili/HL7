using System.Collections.Generic;

namespace Host.Cobas.Lines
{
    public class Line02ControlId : BaseLineCode<Line02ControlId>
    {
        public string QCName { get; private set; }

        public Line02ControlId() : base("02")
        {
        }

        protected override Line02ControlId Assign(List<string> data)
        {
            QCName = data[1];
            return this;
        }
    }
}