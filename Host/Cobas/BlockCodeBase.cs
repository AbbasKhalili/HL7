using Host.Tools;

namespace Host.Cobas
{
    public abstract class BlockCodeBase : CobasIntegra400Base
    {
        private readonly string _deviceName;
        private readonly string _blockCode;

        protected BlockCodeBase(string deviceName, string blockCode)
        {
            _deviceName = deviceName;
            _blockCode = blockCode;
        }

        public virtual string Generate()
        {
            return MakePacket(Build());
        }

        protected string MakePacket(string body)
        {
            return $"{MakeHeader()}{body}{MakeFooter()}";
        }

        protected abstract string Build();

        protected string MakeHeader()
        {
            return SOH + $"14_{_deviceName.ToFixLength(16)}_{_blockCode}{LF}{STX}";
        }

        protected string MakeFooter()
        {
            return LF + ETX + EOT;
        }
    }
}