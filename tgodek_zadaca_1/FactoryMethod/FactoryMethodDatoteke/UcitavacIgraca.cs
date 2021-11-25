using System;
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
                if (postojeciKlub != null)
                {
                    var igrac = ObradaIgraca(value[0], value[1], value[2], value[3]);
                    if (igrac != null)
                        postojeciKlub.DodajKomponentu(igrac);
                }
            }
        }

        private Igrac ObradaIgraca(string klub, string ime, string pozicija, string datum)
        {
            var igracError = "";
          
            if (String.IsNullOrEmpty(ime))
                igracError = "-- Igrac nema ime ";
            
            Pozicija novaPozicija;
            if (!Enum.TryParse(pozicija, out novaPozicija))
                igracError += "-- Igrac nema ispravnu poziciju ";
            
            DateTime noviDatum;
            if (!DateTime.TryParse(datum, out noviDatum))
                igracError += "-- Igrac nema ispravan datum ";

            if (igracError == "")
            {
                var igrac = new Igrac(ime, novaPozicija, noviDatum);
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
