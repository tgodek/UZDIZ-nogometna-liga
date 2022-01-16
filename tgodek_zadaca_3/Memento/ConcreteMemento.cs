using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    class ConcreteMemento : IMemento
    {
        private int Broj { get; set; }
        private bool Vazeci { get; set; }
        private DateTime Datum { get; set; }
        private List<Utakmica> utakmice;

        public ConcreteMemento(int broj, DateTime datum, List<Utakmica> utakmice)
        {
            this.Broj = broj;
            this.Datum = datum;
            this.utakmice = utakmice;
            this.Vazeci = false;
        }

        public DateTime GetDatum()
        {
            return Datum;
        }

        public int GetRaspored()
        {
            return Broj;
        }

        public bool StanjeVazeci()
        {
            return Vazeci;
        }

        public List<Utakmica> GetUtakmice()
        {
            return utakmice;
        }

        public void MakniVazeci()
        {
            this.Vazeci = false;
        }

        public void PostaviVazeci()
        {
            this.Vazeci = true;
        }
    }
}
