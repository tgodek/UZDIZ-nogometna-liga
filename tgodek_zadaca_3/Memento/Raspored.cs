using System;
using System.Collections.Generic;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    class Raspored
    {
        private int Broj { get; set; }
        private DateTime Datum { get; set; }

        private List<Utakmica> Utakmice;

        public Raspored(int broj, DateTime datum, List<Utakmica> utakmice)
        {
            this.Broj = broj;
            this.Datum = datum;
            this.Utakmice = utakmice;
        }

        public int GetBroj() => Broj;

        public DateTime GetDatum() => Datum;

        public List<Utakmica> GetUtakmice() => Utakmice;

    }
}
