using System;

namespace Host.Tools
{
    public static class StringTools
    {
        public static string ToFixLength(this string param, int len)
        {
            var paramLen = param.Length;
            if (paramLen == len) return param;
            if (paramLen > len) return param.Substring(0, len);
            for (var i = 0; i < len - paramLen; i++)
                param += " ";
            return param;
        }

        public static string ToFixLength(this int param, int len) => ToFixLength(param.ToString(), len);
        public static string ToFixZeroLength(this string param, int len)
        {
            var paramLen = param.Length;
            if (paramLen == len) return param;
            if (paramLen > len) return param.Substring(0, len);
            var zero = "";
            for (var i = 0; i < len - paramLen; i++)
                zero += "0";
            return zero + param;
        }

        public static string ToFixZeroLength(this int param, int len) => ToFixZeroLength(param.ToString(), len);
        public static string ToFixLength(this DateTime? param)
        {
            return param == null ? "00/00/0000" : param.Value.Date.ToString("MM/dd/yyyy");
        }
    }
}