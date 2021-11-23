using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    class Utakmica : INogometniKlub
    {
        protected List<INogometniKlub> klubovi = new List<INogometniKlub>();

        public int Broj { get; set; }
        public int Kolo { get; set; }
        public DateTime Pocetak { get; set; }

        public Utakmica(int broj, int kolo, DateTime pocetak, INogometniKlub domacin, INogometniKlub gost)
        {
            Broj = broj;
            Kolo = kolo;
            Pocetak = pocetak;
            klubovi.Add(domacin);
            klubovi.Add(gost);
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("Broj utakmice: {0} Kolo: {1}  Početak: {2}", Broj, Kolo, Pocetak);
            foreach (var klub in klubovi)
            {
                klub.DetaljiKomponente();
            }
        }

        public INogometniKlub KomponentaPostoji(string id)
        {
            if (id == Broj.ToString())
                return this;
            else
                return null;
        }
    }
}
