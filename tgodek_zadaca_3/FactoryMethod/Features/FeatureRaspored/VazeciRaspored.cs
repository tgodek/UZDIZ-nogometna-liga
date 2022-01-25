using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Memento;

namespace tgodek_zadaca_3.Feature
{
    class VazeciRaspored : Operacija
    {
        private int IDRasporeda;
        public VazeciRaspored(int broj) 
        {
            IDRasporeda = broj;
        }

        public override void ObradiZahtjev()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var caretaker = Caretaker.DohvatiCaretaker();
            var raspored = caretaker.PronaziRaspored(IDRasporeda);
            if (raspored == null) 
            {
                Console.WriteLine($"Raspored {IDRasporeda} ne postoji!");
                return;
            }
            prvenstvo.AktivniRaspored.RestoreMemento(raspored);
        }
    }
}
