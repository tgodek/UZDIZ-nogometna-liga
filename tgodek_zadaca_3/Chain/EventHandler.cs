using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    public interface IHandler
    {
        IHandler SetNextHandler(IHandler handler);
        void ProccessEvent(Dogadaj dogadaj);
    }
}
