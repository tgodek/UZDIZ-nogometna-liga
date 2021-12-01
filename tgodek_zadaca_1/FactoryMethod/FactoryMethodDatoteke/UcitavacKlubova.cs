using System;
using tgodek_zadaca_2;
using tgodek_zadaca_2.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacKlubova : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            for (var i = 0; i < list.Count; i++)
            {
                var value = list[i].Split(';');
                var postojeciKlub = prvenstvo.PronadiZapis(value[0]) as Klub;
                if (postojeciKlub == null)
                {
                    var klub = ObradaKluba(value[0], value[1], value[2], i);
                    if (klub != null)
                        prvenstvo.DodajKomponentu(klub);
                }
            }
        }

        private Trener ObradaTrenera(string ime)
        {
            if (!string.IsNullOrEmpty(ime))
            {
                var trener = new Trener(ime);
                return trener;
            }
            return null;
        }

        private Klub ObradaKluba(string oznaka, string naziv, string imeTrenera, int index)
        {
            var klubError = "";
            var trener = ObradaTrenera(imeTrenera);

            if (String.IsNullOrEmpty(oznaka))
                klubError += "-- Klub nema oznaku";

            if (String.IsNullOrEmpty(naziv))
                klubError = "-- Klub nema naziv";

            if (trener == null)
                klubError = "-- Klub nema trenera";

            if (klubError == "")
            {
                var klub = new Klub(oznaka, naziv, trener);
                return klub;
            }
            else
            {
                Console.WriteLine("ZAPIS {0} | KLUB | Preskaćem klub | Razlog: {1} | Podaci: {2} {3} {4}", 
                    index+1, klubError, oznaka, naziv, trener.Ime);
                return null;
            }
        }
    }
}
