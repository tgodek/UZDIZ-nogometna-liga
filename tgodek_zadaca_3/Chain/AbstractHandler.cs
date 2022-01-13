using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNextHandler(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual void ProccessEvent(Dogadaj dogadaj)
        {
            if (this._nextHandler != null)
            {
                this._nextHandler.ProccessEvent(dogadaj);
            }
            else return;
        }
    }
}
