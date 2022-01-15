using System;
using System.Collections.Generic;
using tgodek_zadaca_3.Visitor;

namespace tgodek_zadaca_3.Composite
{
    public class Utakmica : INogometnaLiga
    {
        public List<INogometnaLiga> komponente { get; private set; } = new List<INogometnaLiga>();

        public int Broj { get; set; }
        public int Kolo { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public DateTime Pocetak { get; set; }
        public int RezultatDomacin { get; set; }
        public int RezultatGost { get; set; }
        public bool Odigrana { get; set; }

        public string RezultatUtakmice()
        {
            if (Odigrana)
                return RezultatDomacin.ToString() + " - " + RezultatGost.ToString();
            else return "";
        }

        public Utakmica(int broj, int kolo, Klub domacin, Klub gost, DateTime pocetak)
        {
            Broj = broj;
            Kolo = kolo;
            Pocetak = pocetak;
            Gost = gost;
            Domacin = domacin;
        }

        public void DodajKomponentu(INogometnaLiga komponenta) => komponente.Add(komponenta);

        public bool PostojiDogadaj()
        {
            var postoji = false;
            foreach (var x in komponente)
            {
                if (x.GetType() == typeof(Dogadaj))
                    return true;
            }
            return postoji;
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
                    if(x.GetType() == typeof(SastavUtakmice))
                        if (x.PronadiZapis(id) != null)
                            return komponenta = x.PronadiZapis(id);
                }
            }
            return komponenta;
        }

        public void Accept(IOperation operacija)
        {
            foreach (var komponenta in komponente)
            {
                komponenta.Accept(operacija);
            }
            operacija.Visit(this);

        }

        internal void ResetirajUtakmicu()
        {
            RezultatDomacin = 0;
            RezultatGost = 0;
            Odigrana = false;
        }
    }
}
