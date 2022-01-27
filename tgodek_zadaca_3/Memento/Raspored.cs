using System;
using System.Collections.Generic;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    class Raspored
    {
        public int Broj { get; }
        public DateTime Datum { get; }
        public List<Utakmica> Utakmice { get; }

        public Raspored(int broj, DateTime datum, List<Utakmica> utakmice)
        {
            this.Broj = broj;
            this.Datum = datum;
            this.Utakmice = utakmice;
        }
    }
}
