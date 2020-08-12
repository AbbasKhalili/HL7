using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line15AccessDateTime: BaseLineCode<Line15AccessDateTime>
    {
        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }

        public Line15AccessDateTime() : base("15")
        {
        }

        protected override Line15AccessDateTime Assign(List<string> data)
        {
            Time = data[1].ToTime();
            Date = data[2].ToDate();
            return this;
        }
    }
}