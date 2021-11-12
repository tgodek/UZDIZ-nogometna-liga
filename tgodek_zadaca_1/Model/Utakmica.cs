using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Model
{
    class Utakmica
    {
        public int Broj { get; set; }
        public int Kolo { get; set; }
        public string Domacin { get; set; }
        public string Gost { get; set; }
        public DateTime Pocetak { get; set; }
        private Utakmica(int broj, int kolo, string domacin, string gost, DateTime pocetak)
        {
            this.Broj = broj;
            this.Kolo = kolo;
            this.Domacin = domacin;
            this.Gost = gost;
            this.Pocetak = pocetak;
        }

        static public Utakmica ProvjeriUtakmicu(string broj, string kolo, string domacin, string gost, string pocetak)
        {
            var utakmicaError = "";
            Int32 noviBroj;
            if (!Int32.TryParse(broj, out noviBroj))
            {
                utakmicaError += "-- Utakmica nema broj ";
            }
            Int32 novoKolo;
            if (!Int32.TryParse(kolo, out novoKolo))
            {
                utakmicaError = "-- Utakmica nema kolo ";
            }
            
            if (String.IsNullOrEmpty(domacin))
            {
                utakmicaError = "-- Igrac nema domacina ";
            }

            if (String.IsNullOrEmpty(gost))
            {
                utakmicaError = "-- Igrac nema domacina ";
            }

            DateTime noviPocetak;
            if (!DateTime.TryParse(pocetak, out noviPocetak))
            {
                utakmicaError += "-- Utakmica nema domacina ";
            }

            if (utakmicaError == "")
            {
                var utakmica = new Utakmica(noviBroj,novoKolo,domacin,gost,noviPocetak);
                return utakmica;
            }

            else
            {
                Console.WriteLine("UTAKMICA | Preskacem utakmicu | Razlog: {0}", utakmicaError);
                return null;
            }
        }
    }
}
