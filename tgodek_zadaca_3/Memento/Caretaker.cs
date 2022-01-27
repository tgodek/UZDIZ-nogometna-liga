using System;
using System.Collections.Generic;

namespace tgodek_zadaca_3.Memento
{
    class Caretaker
    {
        private static Caretaker instanca;

        private readonly List<Raspored> rasporedi = new List<Raspored>();

        public static Caretaker DohvatiCaretaker()
        {
            if (instanca == null)
            {
                instanca = new Caretaker();
            }
            return instanca;
        }

        public void Backup(Raspored raspored)
        {
            Console.WriteLine("Raspored pohranjen!");
            this.rasporedi.Add(raspored);
        }
        public int ZadnjiRaspored() => rasporedi.Count;

        public List<Raspored> GetRasporede() => rasporedi; 

        public Raspored PronaziRaspored(int broj) => rasporedi.Find(m => m.Broj == broj);
    }
}
