using System;
using tgodek_zadaca_1;
using tgodek_zadaca_1.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacUtakmica : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            foreach (var item in list)
            {
                var value = item.Split(';');
                ObradaUtakmica(value[0], value[1], value[2], value[3], value[4], prvenstvo);
            }
        }

        private void ObradaUtakmica(string broj, string kolo, string domacin, string gost, string pocetak, Prvenstvo prvenstvo)
        {
            var postojeciDomacin = prvenstvo.PronadiZapis(domacin) as Klub;
            var postojeciGost = prvenstvo.PronadiZapis(gost) as Klub;

            var utakmicaError = "";
            Int32 noviBroj;
            if (!Int32.TryParse(broj, out noviBroj))
                utakmicaError += "-- Utakmica nema broj ";
            
            Int32 novoKolo;
            if (!Int32.TryParse(kolo, out novoKolo))
                utakmicaError = "-- Utakmica nema kolo ";

            if (postojeciDomacin == null)
                utakmicaError = "-- Utakmica nema domacina ";

            if (postojeciGost == null)
                utakmicaError = "-- Utakmica nema gosta ";

            DateTime noviPocetak;
            if (!DateTime.TryParse(pocetak, out noviPocetak))
                utakmicaError += "-- Utakmica nema pocetak ";

            if (utakmicaError == "")
            {
                var utakmica = new Utakmica(noviBroj, novoKolo, postojeciDomacin, postojeciGost ,noviPocetak);
                prvenstvo.DodajKomponentu(utakmica);
            }

            else
                Console.WriteLine("UTAKMICA | Preskacem utakmicu | Razlog: {0}", utakmicaError);
        }
    }
}
