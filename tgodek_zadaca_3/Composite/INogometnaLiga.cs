using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Visitor;

namespace tgodek_zadaca_3.Composite
{
    public interface INogometnaLiga
    {
        public abstract INogometnaLiga PronadiZapis(string id);
        public abstract void Accept(IOperation operacija);
    }
}
