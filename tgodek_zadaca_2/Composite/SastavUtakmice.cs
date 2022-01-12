using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_2.Visitor;

namespace tgodek_zadaca_2.Composite
{
    public class SastavUtakmice : INogometnaLiga
    {
        public Utakmica Utakmica { get; set; }
        public Klub Klub { get; set; }
        public string Vrsta { get; set; }
        public Igrac Igrac { get; set; }
        public Pozicija Pozicija { get; set; }

        public SastavUtakmice(Utakmica utakmica, Klub klub, string vrsta, Igrac igrac, Pozicija pozicija)
        {
            this.Utakmica = utakmica;
            this.Klub = klub;
            this.Vrsta = vrsta;
            this.Igrac = igrac;
            this.Pozicija = pozicija;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == Klub.Oznaka)
                return this;
            else if (id == Igrac.Ime)
                return this;
            else return null;
        }

        public void Accept(IOperation operacija)
        {
            operacija.Visit(this);
        }
    }
}
