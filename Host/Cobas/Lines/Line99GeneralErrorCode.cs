using System.Collections.Generic;
using System.Linq;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line99GeneralErrorCode : BaseLineCode<Line99GeneralErrorCode>
    {
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public Line99GeneralErrorCode() : base("99")
        {
        }

        protected override Line99GeneralErrorCode Assign(List<string> data)
        {
            ErrorCode = data[1];
            ErrorMessage = ErrorCode99.FirstOrDefault(a => a.Key == ErrorCode.ToInt()).Value;
            return this;
        }
    }
}