using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line12ControlLotInfo : BaseLineCode<Line12ControlLotInfo>
    {
        public string ReagentLot { get; private set; }
        public DateTime ReagentExpirationDate { get; private set; }

        public Line12ControlLotInfo() : base("12")
        {
        }

        protected override Line12ControlLotInfo Assign(List<string> data)
        {
            ReagentLot = data[1];
            ReagentExpirationDate = data[2].ToDate();
            return this;
        }
    }
}