using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class LjestvicaPrvenstva : Operacija
    {
        private readonly int Kolo;
        private KlasicnaTablica Tablica;
        private readonly string[] naslovi = { "Naziv kluba", "Oznaka", "Trener", "Broj odigranih kola",
            "Broj pobjeda", "Broj nerješenih","Broj poraza","Broj danih golova", "Broj primljenih golova", "Razlika golova", "Broj bodova"};
        public LjestvicaPrvenstva(int kolo = 0)
        {
            Kolo = kolo;
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {

            var liga = Prvenstvo.DohvatiPrvenstvo();
            var (klubovi, ukSuma) = liga.PripremljenaLjestvicaPrvenstva(Kolo);

            foreach (var klub in klubovi)
            {
                string[] zapis = { klub.Naziv, klub.Oznaka, klub.Trener.Ime, klub.BrojOdigranihKola.ToString(), klub.BrojPobjeda.ToString(),
                klub.BrojNerješenih.ToString(), klub.BrojPoraza.ToString(), klub.BrojDanihGolova.ToString(), klub.BrojPrimljenihGolova.ToString(),
                klub.RazlikaGolova().ToString(), klub.BrojBodova.ToString() };
                Tablica.DodajRedak(zapis);
            }

            Tablica.Ispis();
            liga.Resetiraj();
        }
    }
}
