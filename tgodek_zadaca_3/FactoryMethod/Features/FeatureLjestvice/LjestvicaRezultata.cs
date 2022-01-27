using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class LjestvicaRezultata : Operacija
    {
        private readonly int Kolo;
        private readonly string OznakaKluba;
        private readonly string[] naslovi = { "Kolo", "Datum i vrijeme", "Klub domaćin", "Klub gost", "Rezultat" };
        private KlasicnaTablica Tablica;

        public LjestvicaRezultata(string oznakaKluba, int kolo = 0)
        {
            this.OznakaKluba = oznakaKluba;
            this.Kolo = kolo;
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            var postojiKlub = prvenstvo.PronadiZapis(OznakaKluba);
            if (postojiKlub == null) 
            {
                Console.WriteLine("Klub ne postoji");
                return; 
            }

            var utakmice = prvenstvo.PripremljenaLjestvicaRezultata(OznakaKluba,Kolo);

            foreach (var utakmica in utakmice)
            {
                string[] zapis = { utakmica.Kolo.ToString(), utakmica.Pocetak.ToString(), utakmica.Domacin.Naziv, utakmica.Gost.Naziv, utakmica.RezultatUtakmice() };
                Tablica.DodajRed(zapis);
            }
            Tablica.Ispis();
            prvenstvo.Resetiraj();
        }
    }
}
