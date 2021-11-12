using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Model
{
    class SastavUtakmice
    {
        public int Broj { get; set; }

        public string Klub { get; set; }

        public string Vrsta { get; set; }

        public string Igrac { get; set; }

        public Pozicija Pozicija { get; set; }

        private SastavUtakmice(int broj, string klub, string vrsta, string igrac, Pozicija pozicija)
        {
            this.Broj = broj;
            this.Klub = klub;
            this.Vrsta = vrsta;
            this.Igrac = igrac;
            this.Pozicija = pozicija;
        }
        
        static public SastavUtakmice ProvjeriSastavUtakmice(string broj, string klub, string vrsta, string igrac, string pozicija)
        {
            var sastavUtakmicaError = "";
            Int32 noviBroj;
            if (!Int32.TryParse(broj, out noviBroj))
            {
                sastavUtakmicaError += "-- Ne postoji utakmica ";
            }
            if (String.IsNullOrEmpty(klub))
            {
                sastavUtakmicaError = "-- Ne postoji klub ";
            }

            if (String.IsNullOrEmpty(vrsta))
            {
                sastavUtakmicaError = "-- Ne postoji vrsta sastava ";
            }

            if (String.IsNullOrEmpty(igrac))
            {
                sastavUtakmicaError = "-- Ne postoji igrac";
            }

            Pozicija novaPozicija;
            if (!Enum.TryParse(pozicija, out novaPozicija))
            {
                sastavUtakmicaError += "-- Igrac nema ispravnu poziciju ";

            }

            if (sastavUtakmicaError == "")
            {
                var sastavUtakmice = new SastavUtakmice(noviBroj, klub, vrsta, igrac, novaPozicija);
                return sastavUtakmice;
            }

            else
            {
                Console.WriteLine("UTAKMICA | Preskacem utakmicu | Razlog: {0} | {1} {2} {3} {4} {5}", 
                    sastavUtakmicaError, broj, klub, vrsta, igrac, pozicija);
                return null;
            }
        }


    }
}
