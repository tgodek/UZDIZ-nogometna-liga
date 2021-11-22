using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    abstract class NogometnaLiga
    {
    }

    class Utakmica : NogometnaLiga
    {
        protected List<NogometniKlub> nogometniKlubovi = new List<NogometniKlub>();

        public int Broj { get; set; }
        public int Kolo { get; set; }
        public DateTime Pocetak { get; set; }

        public Utakmica(int broj , int kolo, DateTime pocetak, NogometniKlub klub)
        {
            Broj = broj;
            Kolo = kolo;
            Pocetak = pocetak;
            nogometniKlubovi.Add(klub);
        }
    }

    class SastavUtakmice : NogometnaLiga
    {
        protected List<NogometniKlub> komponenteKluba = new List<NogometniKlub>();
        protected List<NogometnaLiga> komponenteLige = new List<NogometnaLiga>();

        public SastavUtakmice()
        {
        }
    }

}
