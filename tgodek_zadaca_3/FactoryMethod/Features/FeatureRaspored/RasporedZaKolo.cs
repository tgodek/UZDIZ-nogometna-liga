using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class RasporedZaKolo : Operacija
    {
        private KlasicnaTablica Tablica;
        private readonly int Kolo;
        private readonly string[] naslovi = { "Kolo", "Domacin", "Gost" };

        public RasporedZaKolo(int kolo) 
        {
            this.Kolo = kolo;
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            if (prvenstvo.AktivniRaspored.Utakmice == null)
            {
                Console.WriteLine("Nije postavljen važeći raspored!");
                return;
            }

            var utakmice = prvenstvo.AktivniRaspored.Utakmice.Where(u => u.Kolo == Kolo).ToList();
            if (utakmice.Count == 0) return;

            foreach (var utakmica in utakmice)
            {
                string[] zapis = { utakmica.Kolo.ToString(), utakmica.Domacin.Naziv, utakmica.Gost.Naziv };
                Tablica.DodajRed(zapis);
            }
            Tablica.Ispis();
        }
    }
}
