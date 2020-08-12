using System.Collections.Generic;
using System.Linq;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line96ErrorCode : BaseLineCode<Line96ErrorCode>
    {
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public Line96ErrorCode() : base("96")
        {
        }

        protected override Line96ErrorCode Assign(List<string> data)
        {
            ErrorCode = data[1];
            ErrorMessage = ErrorCode96.FirstOrDefault(a=>a.Key == ErrorCode.ToInt()).Value;
            return this;
        }
    }
}