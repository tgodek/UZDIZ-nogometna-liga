using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    public class LjestvicaStrijelci : Operacija
    {
        private readonly int Kolo;
        private readonly string[] naslovi = { "Igrac", "Broj golova", "Naziv kluba", "Oznaka kluba" };
        private KlasicnaTablica Tablica;

        public LjestvicaStrijelci(int kolo) 
        {
            this.Kolo = kolo;
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var (igraci, suma) = prvenstvo.PripremljenaLjestvicaStrijelaca(Kolo);

            foreach (var igrac in igraci)
            {
                string[] zapis = { igrac.Ime, igrac.BrojPogodaka.ToString(), igrac.Klub.Naziv, igrac.Klub.Oznaka };
                Tablica.DodajRedak(zapis);
            }
            Tablica.Ispis();
        }
    }

}
