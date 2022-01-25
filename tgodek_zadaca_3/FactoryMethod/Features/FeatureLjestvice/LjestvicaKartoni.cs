using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    public class LjestvicaKartoni : Operacija
    {
        private readonly int Kolo;
        private readonly string[] naslovi = { "Klub", "Oznaka Kluba", "Zuti Karton", "Drugi zuti karton", "Crveni karton", "Ukupno" };
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

            foreach (var klub in klubovi)
            {
                string[] zapis = { klub.Naziv, klub.Oznaka, klub.ZutiKarton.ToString(),
                    klub.DrugiZutiKarton.ToString(), klub.CrveniKarton.ToString(), klub.UkupnoKartona().ToString()};
                Tablica.DodajRedak(zapis);
            }
            Tablica.Ispis();
            prvenstvo.Resetiraj();
        }
    }
}
