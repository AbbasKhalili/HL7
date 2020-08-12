using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line40ServiceSelection : BaseLineCode<Line40ServiceSelection>
    {
        public ServiceRequestTypes RequestType { get; private set; }


        public Line40ServiceSelection() : base("40") { }


        public static Line40ServiceSelection Create(ServiceRequestTypes requestType)
        {
            return new Line40ServiceSelection()
            {
                RequestType = requestType
            };
        }

        public string Build() => $"{LineCode}_{(int)RequestType}{LF}";
        

        protected override Line40ServiceSelection Assign(List<string> data)
        {
            RequestType = (ServiceRequestTypes)data[1].ToInt();
            return this;
        }
    }

    public enum ServiceRequestTypes
    {
        SlotConfiguration = 0,
        SampleTubesWithoutOrders = 1,
        Reserved = 2,
        ListOfAllSampleTubes = 3
    }
}