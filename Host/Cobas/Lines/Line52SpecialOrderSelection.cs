using System.Collections.Generic;
using Host.Cobas.Blocks;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line52SpecialOrderSelection : BaseLineCode<Line52SpecialOrderSelection>
    {
        public SpecialOrderType SpecialOrderType { get; private set; }
        public string Attribute { get; private set; }
        

        public Line52SpecialOrderSelection() : base("52")
        {
        }

        public static Line52SpecialOrderSelection Create(SpecialOrderType specialOrderType, string attribute)
        {
            return new Line52SpecialOrderSelection()
            {
                Attribute = attribute,
                SpecialOrderType = specialOrderType
            };
        }

        
        public string Build() => $"{LineCode}_0{(int)SpecialOrderType}_{Attribute.ToFixLength(1)}{LF}";

        protected override Line52SpecialOrderSelection Assign(List<string> data)
        {
            SpecialOrderType = (SpecialOrderType)data[1].ToInt();
            Attribute = data[2];
            return this;
        }
    }
}