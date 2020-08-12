using System.Collections.Generic;

namespace Host.Cobas.Lines
{
    public class Line01ResultTime : BaseLineCode<Line01ResultTime>
    {
        public string Time { get; private set; }

        public Line01ResultTime():base("01"){}

        protected override Line01ResultTime Assign(List<string> data)
        {
            Time = data[1];
            return this;
        }
    }
}