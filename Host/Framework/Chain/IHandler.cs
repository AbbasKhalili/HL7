using System;
using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Blocks;
using Host.Cobas.Lines;

namespace Host.Framework.Chain
{
    public interface IHandler<THeader,TBody>
    {
        void Handle(THeader header, TBody body, List<ILineCode> response);
        void SetNext(IHandler<THeader, TBody> handler);

    }

    public abstract class BaseChainHandler<THeader, TBody> : IHandler<THeader, TBody>
    {
        private IHandler<THeader, TBody> _nextHandler;
        public abstract void Handle(THeader header, TBody body, List<ILineCode> response);

        public void SetNext(IHandler<THeader, TBody> handler)
        {
            this._nextHandler = handler;
        }

        protected void CallNext(THeader header, TBody body, List<ILineCode> response)
        {
            _nextHandler?.Handle(header, body, response);
        }
    }

    public class ChainBuilder<THeader, TBody>
    {
        private readonly List<IHandler<THeader, TBody>> _handlers;

        public ChainBuilder()
        {
            this._handlers = new List<IHandler<THeader, TBody>>();
        }

        public ChainBuilder<THeader, TBody> WithHandler(IHandler<THeader, TBody> handler)
        {
            this._handlers.Add(handler);
            return this;
        }

        public IHandler<THeader, TBody> Build()
        {
            if (!_handlers.Any()) throw new Exception("No handler has been added");

            _handlers.Aggregate((a, b) =>
            {
                a.SetNext(b);
                return b;
            });
            return _handlers.First();
        }
    }
}
