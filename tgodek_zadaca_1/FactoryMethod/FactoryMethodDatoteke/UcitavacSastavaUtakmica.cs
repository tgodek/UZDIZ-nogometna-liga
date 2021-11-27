using System;
using tgodek_zadaca_1;
using tgodek_zadaca_1.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacSastavaUtakmica : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            foreach (var item in list)
            {
                var value = item.Split(';');
                ObradaSatavaUtakmice(value[0], value[1], value[2], value[3], value[4], prvenstvo);
            }
        }

        private SastavUtakmice ObradaSatavaUtakmice(string broj, string klub, string vrsta, string igrac, string pozicija, Prvenstvo prvenstvo)
        {
            var utakmica = prvenstvo.PronadiZapis(broj) as Utakmica;
            Klub postojeciKlub = null;
            Igrac postojeciIgrac = null;

            if (utakmica != null)
            {
                postojeciKlub = utakmica.Domacin.PronadiZapis(klub) as Klub;
                if(postojeciKlub == null)
                    postojeciKlub = utakmica.Gost.PronadiZapis(klub) as Klub;
            }

            if (postojeciKlub != null)
                postojeciIgrac = postojeciKlub.PronadiZapis(igrac) as Igrac;

            var sastavUtakmicaError = "";
            if (utakmica == null)
                sastavUtakmicaError += "-- Ne postoji utakmica ";
            
            if (postojeciKlub == null)
                sastavUtakmicaError = "-- Ne postoji klub ";

            if (String.IsNullOrEmpty(vrsta))
                sastavUtakmicaError = "-- Ne postoji vrsta sastava ";

            if (postojeciIgrac == null)
                sastavUtakmicaError = "-- Ne postoji igrac";

            Pozicija novaPozicija;
            if (!Enum.TryParse(pozicija, out novaPozicija))
                sastavUtakmicaError += "-- Igrac nema ispravnu poziciju ";

            if (sastavUtakmicaError == "")
            {
                var sastavUtakmice = new SastavUtakmice(utakmica, postojeciKlub, vrsta, postojeciIgrac, novaPozicija);
                utakmica.DodajKomponentu(sastavUtakmice);
                return sastavUtakmice;
            }

            else
            {
                Console.WriteLine("SASTAV UTAKMICE | Preskacem sastav utakmice | Razlog: {0} | {1} {2} {3} {4} {5}",
                    sastavUtakmicaError, broj, klub, vrsta, igrac, pozicija);
                return null;
            }
        }
    }
}
