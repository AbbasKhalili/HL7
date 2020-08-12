using System;

namespace Host.Tools
{
    public static class DateTimeTools
    {
        public static DateTime ToDate(this string param, string format= "dd/MM/yyyy")
        {
            if (param == "00/00/0000") return default;
            return param == null ? default : DateTime.ParseExact(param, format, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static DateTime ToTime(this string param)
        {
            return param == null ? default : DateTime.ParseExact(param, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}