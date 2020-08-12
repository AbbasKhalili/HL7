using System.Text;

namespace Host.Cobas
{
    public abstract class CobasBase
    {
        public static readonly string LF = Encoding.ASCII.GetString(new byte[] { 10 });
        public static readonly string SOH = Encoding.ASCII.GetString(new byte[] { 1 }) + LF;
        public static readonly string STX = Encoding.ASCII.GetString(new byte[] { 2 }) + LF;
        public static readonly string ETX = Encoding.ASCII.GetString(new byte[] { 3 }) + LF;
        public static readonly string EOT = Encoding.ASCII.GetString(new byte[] { 4 }) + LF;
    }
}