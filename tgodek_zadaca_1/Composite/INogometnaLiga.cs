using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_2.Visitor;

namespace tgodek_zadaca_2.Composite
{
    public interface INogometnaLiga
    {
        public abstract void DetaljiKomponente();
        public abstract INogometnaLiga PronadiZapis(string id);
        public abstract void Accept(IOperation operacija);
    }
}
