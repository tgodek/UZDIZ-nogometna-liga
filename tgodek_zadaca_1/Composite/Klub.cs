using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    public class Klub : INogometniKlub
    {
        protected List<INogometniKlub> igraci = new List<INogometniKlub>();
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public INogometniKlub Trener { get; set; }

        public void DodajKomponentu(Igrac igrac)
        {
            igraci.Add(igrac);
        }

        public Klub(string oznaka, string naziv, Trener trener)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Trener = trener;
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("Oznaka kluba: {0}, Naziv kluba: {1}", Oznaka, Naziv);
            foreach(var x in igraci)
            {
                x.DetaljiKomponente();
            }
        }
        public INogometniKlub KomponentaPostoji(string id)
        {
            if (id == Oznaka)
                return this;
            else
                return null;
        }
    }
}
