using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    class Utakmica : INogometnaLiga
    {
        protected List<INogometnaLiga> komponente = new List<INogometnaLiga>();

        public int Broj { get; set; }
        public int Kolo { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public DateTime Pocetak { get; set; }

        public Utakmica(int broj, int kolo, Klub domacin, Klub gost, DateTime pocetak)
        {
            Broj = broj;
            Kolo = kolo;
            Pocetak = pocetak;
            Gost = gost;
            Domacin = domacin;
            komponente.Add(domacin);
            komponente.Add(gost);
        }

        public void DodajKomponentu(INogometnaLiga komponenta)
        {
            komponente.Add(komponenta);
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("Broj utakmice: {0} Kolo: {1}  Početak: {2}, Domacin: {3} Gost: {4}", Broj, Kolo, Pocetak, Domacin.Naziv, Gost.Naziv);
            foreach (var klub in komponente)
            {
                klub.DetaljiKomponente();
            }
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            if (id == Broj.ToString()) 
            {
                komponenta = this;
            }
            else
            {
                foreach (var x in komponente)
                {
                    if (x.PronadiZapis(id) != null)
                    {
                        return komponenta = x.PronadiZapis(id);
                    }
                }
            }
            return komponenta;
        }
    }
}
