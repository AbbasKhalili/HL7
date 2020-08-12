namespace Host.Tools
{
    public static class NumberTools
    {
        public static byte ToByte(this string param)
        {
            byte.TryParse(param, out var result);
            return result;
        }
        public static int ToInt(this string param)
        {
            int.TryParse(param, out var result);
            return result;
        }

        public static long ToLong(this string param)
        {
            long.TryParse(param, out var result);
            return result;
        }

        public static double ToDouble(this string param)
        {
            double.TryParse(param.Replace(".",","), out var result);
            return result;
        }
        public static float ToFloat(this string param)
        {
            float.TryParse(param.Replace(".", ","), out var result);
            return result;
        }
    }
}