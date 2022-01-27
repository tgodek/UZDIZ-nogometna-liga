using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    public class LjestvicaKartoni : Operacija
    {
        private readonly int Kolo;
        private readonly string[] naslovi = { "Klub", "Zuti Karton", "Drugi zuti karton", "Crveni karton", "Ukupno" };
        private KlasicnaTablica Tablica;

        public LjestvicaKartoni(int kolo = 0)
        {
            this.Kolo = kolo; 
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var (klubovi, suma) = prvenstvo.PripremljenaLjestvicaKartona(Kolo);
            List<Tuple<int, string>> podnozje = new List<Tuple<int, string>>();

            podnozje.Add(new Tuple<int, string>(1, suma.UkZutih.ToString()));
            podnozje.Add(new Tuple<int, string>(2, suma.UkDrugihZutih.ToString()));
            podnozje.Add(new Tuple<int, string>(3, suma.UkCrvenih.ToString()));
            podnozje.Add(new Tuple<int, string>(4, suma.Ukupno().ToString()));

            foreach (var klub in klubovi)
            {
                string[] zapis = { klub.Naziv, klub.ZutiKarton.ToString(),
                    klub.DrugiZutiKarton.ToString(), klub.CrveniKarton.ToString(), klub.UkupnoKartona().ToString()};
                Tablica.DodajRed(zapis);
            }
            Tablica.Ispis();
            Tablica.IspisiPodnozje(podnozje);
            prvenstvo.Resetiraj();
        }
    }
}
