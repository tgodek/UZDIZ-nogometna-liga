using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    public class Klub : INogometnaLiga
    {
        protected List<INogometnaLiga> igraci = new List<INogometnaLiga>();
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public Trener Trener { get; set; }

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
            Console.WriteLine("  |-- Oznaka kluba: {0}, Naziv kluba: {1} Trener: {2}", Oznaka, Naziv, Trener.Ime);
            foreach(var x in igraci)
            {
                x.DetaljiKomponente();
            }
        }

        public INogometnaLiga IgracPostoji(string ime)
        {
            INogometnaLiga komponenta = null;
            foreach (var igrac in igraci)
            {
                if (igrac.PronadiZapis(ime) != null)
                    komponenta = igrac.PronadiZapis(ime);
            }
            return komponenta;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            if (id == Oznaka)
                komponenta = this;
            else 
            {
                foreach (var x in igraci)
                {
                    if (x.PronadiZapis(id) != null)
                        komponenta = x.PronadiZapis(id);
                }
            }
           
            return komponenta;
        }
    }
}
