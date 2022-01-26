using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_3.Memento
{
    class Caretaker
    {
        private static Caretaker instanca;

        private readonly List<Raspored> _mementos = new List<Raspored>();

        public static Caretaker DohvatiCaretaker()
        {
            if (instanca == null)
            {
                instanca = new Caretaker();
            }
            return instanca;
        }

        public void Backup(Raspored memento)
        {
            Console.WriteLine("Raspored pohranjen!");
            this._mementos.Add(memento);
        }
        public int ZadnjiRaspored() => _mementos.Count;

        public List<Raspored> GetRasporede() => _mementos; 

        public Raspored PronaziRaspored(int broj) => _mementos.Find(m => m.GetBroj() == broj);
    }
}
