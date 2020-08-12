using System.Collections.Generic;

namespace Host.Cobas
{
    public abstract class CobasIntegra400Base : CobasBase
    {
        public static readonly Dictionary<int, string> ErrorCode96 = new Dictionary<int, string>
        {
            {0,"OK"},
            {11,"Patient ID not found.(Patient Entry/Modify/Delete)"},
            {12,"Patient ID already exists.(Patient Entry)"},
            {13,"Patient already locked (e.g. by work area etc.) or database time-out.(Pat.Entry/Mod./Delete)"},
            {14,"Patient still has open orders"},
            {21,"Sample ID (Order No./Sample Type/Order Date) not found. | Attempt to change orders to passive priority. | No appropriate orders found to change priority | No appropriate tests found in order; No tests removed"},
            {22,"Sample ID already exists; rack/sample position already in use. | Sample order full (50 test orders already assigned). Calibration/Control request already set"},
            {23,"Order already locked (e.g. by work area, etc.), or Database time-out"},
            {24,"Test not defined"},
            {25,"Order contains not-yet accepted results"},
            {33,"Result data already locked.Or: any database error such as: 1.Sample type not found in sample type list. 2.Result has just been deleted. 3.Database time-out"},
            {40,"No communication with real time software."},
            {41,"The current instrument status does not allow the required/requested change."},
            {52,"No cassette on board."},
            {55,"No pending tests."},
            {56,"Selected Order is not present"},
            {58,"No tests loaded"},
            {59,"The specified test is not loaded"},
            {61,"No tubes found"},
            {63,"Sample type not found in sample type list. | No test defined. | Database time-out."},
            {65,"No test is loaded."},
            {66,"No Service Action definition is available."},
            {80,"No new message to send."},
            {81,"No new service action result to send."},
            {91,"General parameter range error (e.g. rack not defined, illegal:cup position, sex, dates, etc.) | Unexpected character in number field. | Sample type (undefined, *** or ??? are inappropriate). | Sample type (lab number) not found."}
        };

        public static readonly Dictionary<int, string> ErrorCode99 = new Dictionary<int, string>
        {
            {1, "Block check sum error. Transmission error."},
            {2, "Parity error. Transmission error."},
            {3, "Line too long (>128 characters). Erroneous line configuration, or possibly transmission error if block check off"},
            {4, "Block too long. Erroneous block configuration, or possibly transmission error if block check off"},
            {5, "Invalid message configuration. Erroneous message configuration, or possibly transmission error if block check off"},
            {6, "Invalid block code. Invalid block code, or possibly transmission error if block check off"},
            {7, "Invalid line code. Invalid line code, or wrong mode used (patient/sample), or possibly transmission error if block check off"},
            {8, "Line format error. Erroneous line configuration, or possibly transmission error if block check off"}
        };
    }
}