using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line13CalibratorLotInfo : BaseLineCode<Line13CalibratorLotInfo>
    {
        public string CalibrationLot { get; private set; }
        public DateTime CalibrationExpirationDate { get; private set; }

        public Line13CalibratorLotInfo() : base("13")
        {
        }

        protected override Line13CalibratorLotInfo Assign(List<string> data)
        {
            CalibrationLot = data[1];
            CalibrationExpirationDate = data[2].ToDate();
            return this;
        }
    }
}