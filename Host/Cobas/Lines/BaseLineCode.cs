using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Blocks;

namespace Host.Cobas.Lines
{
    public abstract class BaseLineCode<T> : CobasIntegra400Base, ILineCode where T : class, new()
    {
        public string LineCode;

        protected BaseLineCode(string lineCode)
        {
            LineCode = lineCode;
        }
        public virtual T Detect(string response)
        {
            var result = new T();
            if (string.IsNullOrEmpty(response))
                return result;

            var data = response.Split(" ").ToList();
            data.RemoveAll(a => a == "");
            return Assign(data);
        }

        protected abstract T Assign(List<string> data);
    }
}