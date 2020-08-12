using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line97SystemStatus : BaseLineCode<Line97SystemStatus>
    {
        public SystemStatus SystemStatus { get; private set; }
        public CleanerStatus CleanerStatus { get; private set; }
        public CuvetteStatus CuvetteStatus { get; private set; }
        public WaterSupplyStatus WaterSupplyStatus { get; private set; }
        public CuvetteWasteStatus CuvetteWasteStatus {get; private set; }
        public int CuvetteWasteCount { get; private set; }
        public WasteDrainStatus WasteDrainStatus { get; private set; }
        public float AnalyzerTemperature { get; private set; }
        public float CassettesTemperature { get; private set; }
        public float CleanerTemperature { get; private set; }



        public Line97SystemStatus() : base("97")
        {
        }

        protected override Line97SystemStatus Assign(List<string> data)
        {
            SystemStatus = (SystemStatus)data[1].ToInt();
            CleanerStatus = (CleanerStatus)data[2].ToInt();
            CuvetteStatus = (CuvetteStatus)data[3].ToInt();
            WaterSupplyStatus = (WaterSupplyStatus)data[4].ToInt();
            CuvetteWasteStatus = (CuvetteWasteStatus)data[5].ToInt();
            CuvetteWasteCount = data[6].ToInt();
            WasteDrainStatus = (WasteDrainStatus)data[7].ToInt();
            AnalyzerTemperature = data[8].ToFloat();
            CassettesTemperature = data[9].ToFloat();
            CleanerTemperature = data[10].ToFloat();
            return this;
        }
    }

    public enum SystemStatus
    {
        Sleeping = 0,
        Initializing = 1,
        Stopped = 2,
        Service = 3,
        CoverOpen = 4,
        Standby = 5,
        Running = 6,
        FatalError = 7,
        PowerDown = 8,
        AutoService = 9,
        PowerOn = 10
    }

    public enum CleanerStatus
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }

    public enum CuvetteStatus
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }

    public enum WaterSupplyStatus
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }

    public enum CuvetteWasteStatus
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }

    public enum WasteDrainStatus
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }
}