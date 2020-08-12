using System.Collections.Generic;
using Host.Cobas.Blocks;
using Host.Cobas.Lines;
using Host.Framework.Chain;

namespace Host.Cobas
{
    public abstract class TemplateRequestChainHandler<T,TBody> : BaseChainHandler<T, TBody> 
    {
        protected abstract bool CanHandleRequest(T header);
        protected abstract void HandleRequest(TBody body, List<ILineCode> response);

        public override void Handle(T header, TBody body, List<ILineCode> response)
        {
            if (CanHandleRequest(header))
            {
                HandleRequest(body,response);
                return;
            }
            else
            {
                CallNext(header, body,response);
            }
        }
    }
}