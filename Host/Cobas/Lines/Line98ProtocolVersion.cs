using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line98ProtocolVersion : BaseLineCode<Line98ProtocolVersion>
    {
        public int ProtocolVersion { get; private set; }

        public Line98ProtocolVersion() : base("98")
        {
        }

        protected override Line98ProtocolVersion Assign(List<string> data)
        {
            ProtocolVersion = data[1].ToInt();
            return this;
        }
    }
}