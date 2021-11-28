﻿using System;
using tgodek_zadaca_1;
using tgodek_zadaca_1.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacIgraca : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            foreach (var item in list)
            {
                var value = item.Split(';');
                var postojeciKlub = prvenstvo.PronadiZapis(value[0]) as Klub;
                var igrac = ObradaIgraca(value[0], value[1], value[2], value[3], prvenstvo);
                if (igrac != null)
                    postojeciKlub.DodajKomponentu(igrac);
              
            }
        }

        private Igrac ObradaIgraca(string klub, string ime, string pozicija, string datum, Prvenstvo prvenstvo)
        {
            var postojeciKlub = prvenstvo.PronadiZapis(klub) as Klub;
            var postojeciIgrac = prvenstvo.PronadiZapis(ime) as Igrac;

            var igracError = "";

            if(postojeciKlub == null)
                igracError = "-- Klub ne postoji ";

            if (String.IsNullOrEmpty(ime))
                igracError = "-- Igrac nema ime ";

            if (postojeciIgrac != null)
                igracError = "-- Igrac vec igra za jedan klub";
            
            Pozicija novaPozicija;
            if (!Enum.TryParse(pozicija, out novaPozicija))
                igracError += "-- Igrac nema ispravnu poziciju ";
            
            DateTime noviDatum;
            if (!DateTime.TryParse(datum, out noviDatum))
                igracError += "-- Igrac nema ispravan datum ";
            if(noviDatum > DateTime.Today)
                igracError += "-- Igrac nema ispravan datum ";

            if (igracError == "")
            {
                var igrac = new Igrac(postojeciKlub,ime, novaPozicija, noviDatum);
                return igrac;
            }
            else
            {
                Console.WriteLine("IGRAC | Preskacem igraca | Razlog: {0} | {1} {2} {3} {4}", 
                    igracError, klub, ime, pozicija, datum);
                return null;
            }
        }
    }
}
