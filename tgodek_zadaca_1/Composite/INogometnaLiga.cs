using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Composite
{
    public interface INogometnaLiga
    {
        public abstract void DetaljiKomponente();
        public abstract INogometnaLiga PronadiZapis(string id);
    }
}
