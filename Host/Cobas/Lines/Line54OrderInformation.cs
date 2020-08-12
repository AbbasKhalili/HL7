using System.Collections.Generic;
using Host.Cobas.Blocks;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line54OrderInformation : BaseLineCode<Line54OrderInformation>
    {
        public int SamplePositionRackNumber { get; private set; } //if 0 Defined by barcode => range(1..999)
        public int SamplePositionTubeNumber { get; private set; } //if 0 Defined by barcode => range(1..15)
        public OrderPriority OrderPriority { get; private set; }
        public string SampleLeaderText1 { get; private set; }
        public string SampleLeaderText2 { get; private set; }

        public Line54OrderInformation() : base("54") { }

        public static Line54OrderInformation Create(int rackNumber, int tubeNumber, OrderPriority orderPriority,string leaderText1="", string leaderText2="")
        {
            return new Line54OrderInformation()
            {
                SamplePositionRackNumber = rackNumber,
                SamplePositionTubeNumber = tubeNumber,
                OrderPriority = orderPriority,
                SampleLeaderText1 = leaderText1,
                SampleLeaderText2 = leaderText2
            };
        }

        public string Build()
        {
            var text1 = !string.IsNullOrEmpty(SampleLeaderText1) ? "_" + SampleLeaderText1.ToFixLength(21) : "";
            var text2 = !string.IsNullOrEmpty(SampleLeaderText2) ? "_" + SampleLeaderText2.ToFixLength(21) : "";
            return $"{LineCode}_{SamplePositionRackNumber.ToFixZeroLength(3)}_" +
                   $"{SamplePositionTubeNumber.ToFixZeroLength(2)}_{(char)OrderPriority}{text1}{text2}{LF}";
        }


        protected override Line54OrderInformation Assign(List<string> data)
        {
            SamplePositionRackNumber = data[1].ToInt();
            SamplePositionTubeNumber = data[2].ToInt();
            OrderPriority = (OrderPriority)data[3][0];
            SampleLeaderText1 = data.Count >= 5 ? data[4] : "";
            SampleLeaderText2 = data.Count >= 6 ? data[5] : "";
            return this;
        }
    }
}