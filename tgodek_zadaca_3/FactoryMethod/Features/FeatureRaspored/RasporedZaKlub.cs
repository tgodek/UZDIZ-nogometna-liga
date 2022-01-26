using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class RasporedZaKlub : Operacija
    {
        private KlasicnaTablica Tablica;
        private readonly string OznakaKluba;
        private readonly string[] naslovi = { "Kolo", "Domacin", "Gost"};
        public RasporedZaKlub(string oznakaKluba) 
        {
            this.OznakaKluba = oznakaKluba;
            Tablica = new KlasicnaTablica(naslovi);
        }
        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            if (prvenstvo.PronadiZapis(OznakaKluba) == null)
            {
                Console.WriteLine("Ne postoji klub s oznakom " + OznakaKluba);
                return;
            }
            if (prvenstvo.AktivniRaspored.Utakmice == null)
            {
                Console.WriteLine("Nije postavljen važeći raspored!");
                return;
            }

            var utakmice = prvenstvo.AktivniRaspored.Utakmice.Where(u => u.Domacin.Oznaka == OznakaKluba || u.Gost.Oznaka == OznakaKluba).ToList();

            foreach (var utakmica in utakmice)
            {
                string[] zapis = { utakmica.Kolo.ToString(), utakmica.Domacin.Naziv, utakmica.Gost.Naziv };
                Tablica.DodajRedak(zapis);
            }
            Tablica.Ispis();
        }
    }
}
