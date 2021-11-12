using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tgodek_zadaca_1.Model
{
    enum Pozicija
    {
        G,
        B,
        V,
        N,
        LB,
        DB,
        CB,
        LDV,
        DDV,
        CDV,
        LV,
        DV,
        CV,
        LOV,
        DOV,
        COV,
        LN,
        DN,
        CN
    }

    class Igrac
    {
        public string Klub { get; set; }
        public string Ime { get; set; }
        public Pozicija Pozicija { get; set; }
        public DateTime Datum { get; set; }

        public int Golovi { get; set; }
        public int ZutiKarton { get; set; }
        public int DrugiZutiKarton { get; set; }
        public int CrveniKarton { get; set; }

        private Igrac(string klub, string ime, Pozicija pozicija, DateTime datum)
        {
            this.Klub = klub;
            this.Ime = ime;
            this.Pozicija = pozicija;
            this.Datum = datum;
        }

        public void ResetIgracStat()
        {
            this.Golovi = 0;
            this.ZutiKarton = 0;
            this.DrugiZutiKarton = 0;
            this.CrveniKarton = 0;
        }

        static public Igrac ProvjeriIgraca(string klub, string ime, string pozicija, string datum)
        {
            var igracError = "";
            if (String.IsNullOrEmpty(klub))
            {
                igracError += "-- Igrac nema klub ";
            }
            if (String.IsNullOrEmpty(ime))
            {
                igracError = "-- Igrac nema ime ";
            }
            Pozicija novaPozicija;
            if (!Enum.TryParse(pozicija, out novaPozicija))
            {
                igracError += "-- Igrac nema ispravnu poziciju ";

            }
            DateTime noviDatum;
            if (!DateTime.TryParse(datum, out noviDatum))
            {
                igracError += "-- Igrac nema ispravan datum ";
            }

            if (igracError == "")
            {
                var igrac = new Igrac(klub, ime, novaPozicija, noviDatum);
                return igrac;
            }
            else
            {
                Console.WriteLine("IGRAC | Preskacem igraca | Razlog: {0} | {1} {2} {3} {4}", igracError, klub, ime, pozicija, datum);
                return null;
            }
        }
    }
}
