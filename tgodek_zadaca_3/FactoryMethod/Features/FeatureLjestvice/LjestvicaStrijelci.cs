using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    public class LjestvicaStrijelci : Operacija
    {
        private readonly int Kolo;
        private readonly string[] naslovi = { "Igrac", "Naziv kluba", "Broj golova" };
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
            List<Tuple<int, string>> podnozje = new List<Tuple<int, string>>();

            podnozje.Add(new Tuple<int, string>(2, suma.ToString()));

            foreach (var igrac in igraci)
            {
                string[] zapis = { igrac.Ime, igrac.Klub.Naziv, igrac.BrojPogodaka.ToString() };
                Tablica.DodajRedak(zapis);
            }

            Tablica.Ispis();
            Tablica.IspisiPodnozje(podnozje);
            prvenstvo.Resetiraj();
        }
    }

}
