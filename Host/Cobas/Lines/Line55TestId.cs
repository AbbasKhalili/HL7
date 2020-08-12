using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line55TestId : BaseLineCode<Line55TestId>
    {
        public int TestNo { get; private set; }

        public Line55TestId() :base("55"){ }
        
        public static Line55TestId Create(int testId)
        {
            return new Line55TestId {TestNo = testId};
        }

        public string Build() => $"{LineCode}_{TestNo.ToFixZeroLength(3)}{LF}";
        
        protected override Line55TestId Assign(List<string> data)
        {
            TestNo = data[1].ToInt();
            return this;
        }
    }
}