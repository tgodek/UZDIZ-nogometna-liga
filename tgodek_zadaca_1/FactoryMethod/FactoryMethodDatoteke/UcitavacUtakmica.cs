using System;
using tgodek_zadaca_2;
using tgodek_zadaca_2.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacUtakmica : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            for (var i = 0; i < list.Count; i++)
            {
                var value = list[i].Split(';');
                ObradaUtakmica(value[0], value[1], value[2], value[3], value[4], prvenstvo, i);
            }
        }

        private void ObradaUtakmica(string broj, string kolo, string domacin, string gost, string pocetak, Prvenstvo prvenstvo, int index)
        {
            var postojeciDomacin = prvenstvo.PronadiZapis(domacin) as Klub;
            var postojeciGost = prvenstvo.PronadiZapis(gost) as Klub;

            var utakmicaError = "";
            Int32 noviBroj;
            if (!Int32.TryParse(broj, out noviBroj))
                utakmicaError += "-- Utakmica nema broj ";
            
            Int32 novoKolo;
            if (!Int32.TryParse(kolo, out novoKolo))
                utakmicaError = "-- Utakmica nema ispravno kolo ";

            if (postojeciDomacin == null)
                utakmicaError = "-- Utakmica nema ispravnog domacina ";

            if (postojeciGost == null)
                utakmicaError = "-- Utakmica nema ispravnog gosta ";

            DateTime noviPocetak;
            if (!DateTime.TryParse(pocetak, out noviPocetak))
                utakmicaError += "-- Utakmica nema ispravan pocetak ";

            if (utakmicaError == "")
            {
                var utakmica = new Utakmica(noviBroj, novoKolo, postojeciDomacin, postojeciGost ,noviPocetak);
                prvenstvo.DodajKomponentu(utakmica);
            }

            else
                Console.WriteLine("ZAPIS {0} | UTAKMICA | Preskacem utakmicu | Razlog: {1} | {2} {3} {4} {5} {6}", 
                    index+1, utakmicaError, broj, kolo, domacin, gost, pocetak);
        }
    }
}
