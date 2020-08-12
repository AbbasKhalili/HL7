using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line11ReagentLotInfo : BaseLineCode<Line11ReagentLotInfo>
    {
        public string ReagentLot { get; private set; }
        public DateTime ReagentExpirationDate { get; private set; }

        public Line11ReagentLotInfo() : base("11")
        {
        }

        protected override Line11ReagentLotInfo Assign(List<string> data)
        {
            ReagentLot = data[1];
            ReagentExpirationDate = data[2].ToDate();
            return this;
        }
    }
}