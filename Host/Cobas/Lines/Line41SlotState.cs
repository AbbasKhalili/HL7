using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line41SlotState : BaseLineCode<Line41SlotState>
    {
        public int RackNumberInSlot1 { get; private set; }
        public int RackNumberInSlot2 { get; private set; }
        public int RackNumberInSlot3 { get; private set; }
        public int RackNumberInSlot4 { get; private set; }
        public int RackNumberInSlot5 { get; private set; }
        public int RackNumberInSlot6 { get; private set; }

        public Line41SlotState() : base("41") { }
        

        protected override Line41SlotState Assign(List<string> data)
        {
            RackNumberInSlot1 = data[1].ToInt();
            RackNumberInSlot2 = data[2].ToInt();
            RackNumberInSlot3 = data[3].ToInt();
            RackNumberInSlot4 = data[4].ToInt();
            RackNumberInSlot5 = data[5].ToInt();
            RackNumberInSlot6 = data[6].ToInt();
            return this;
        }
    }
}