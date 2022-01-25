using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Memento;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class PohranjeniRasporedi : Operacija
    {
        private KlasicnaTablica Tablica;
        private readonly string[] naslovi = { "Raspored", "Datum generiranja" };

        public PohranjeniRasporedi() 
        {
            Tablica = new KlasicnaTablica(naslovi);
        }

        public override void ObradiZahtjev()
        {
            var caretaker = Caretaker.DohvatiCaretaker();
            var rasporedi = caretaker.GetRasporede();

            if (rasporedi.Count == 0)
            {
                Console.WriteLine("Nema pohranjenih rasporeda!");
                return;
            }

            foreach (var raspored in rasporedi)
            {
                string[] zapis = { raspored.GetBroj().ToString(), raspored.GetDatum().ToString() };
                Tablica.DodajRedak(zapis);
            }
            Tablica.Ispis();

        }
    }
}
