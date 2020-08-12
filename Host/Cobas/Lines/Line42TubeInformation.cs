using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line42TubeInformation : BaseLineCode<Line42TubeInformation>
    {
        public int SamplePositionRackNumber { get; private set; }  //if 0 Defined by barcode => range(1..999)
        public int SamplePositionTubeNumber { get; private set; }  //if 0 Defined by barcode => range(1..15)
        public TubeTypes TubeType { get; private set; }
        public string OrderNumber { get; private set; }
        public string SampleType { get; private set; }
        

        public Line42TubeInformation() : base("42") { }


        protected override Line42TubeInformation Assign(List<string> data)
        {
            SamplePositionRackNumber = data[1].ToInt();
            SamplePositionTubeNumber = data[2].ToInt();
            TubeType = (TubeTypes)data[3].ToInt();
            OrderNumber = data[4];
            SampleType = data.Count >= 6 ? data[5] : "";
            return this;
        }
    }

    public enum TubeTypes
    {
        FixedPositionTube = 0,
        BarcodeTube = 1
    }
}