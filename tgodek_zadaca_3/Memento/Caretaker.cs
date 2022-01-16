using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    class Caretaker
    {
        private static Caretaker instanca;

        private List<IMemento> _mementos = new List<IMemento>();

        private Caretaker()
        {
        }

        public static Caretaker DohvatiCaretaker()
        {
            if (instanca == null)
            {
                instanca = new Caretaker();
            }
            return instanca;
        }

        public void Undo(int raspored)
        {
            if (this._mementos.Count == 0) 
            {
                return;
            }
            var memento = _mementos.Find(m => m.GetRaspored() == raspored);
            if (memento != null)
                memento.PostaviVazeci();
            else 
            {
                Console.WriteLine();
                return;
            }

            var vazeci = this._mementos.Where(m => m.StanjeVazeci() == true).ToList();
            if (vazeci != null) 
            {
                foreach (var elem in vazeci)
                    elem.MakniVazeci();
            }
           
           
        }

        public void Backup(IMemento memento)
        {
            Console.WriteLine("Raspored pohranjen.");
            this._mementos.Add(memento);
        }

        public int ZadnjiRaspored() => _mementos.Count;

        public void PrikaziPohranjene()
        {
            if (ZadnjiRaspored() == 0)
            {
                Console.WriteLine("Nema spremljenih rasporeda!\n");
                return;
            }
            else
            {
                foreach (var memento in this._mementos)
                {
                    var utakmice = memento.GetUtakmice();
                    if (utakmice != null)
                    {
                        foreach (Utakmica utakmica in utakmice)
                        {
                            Console.WriteLine(memento.GetRaspored() + " " + memento.GetDatum() + " " + utakmica.Kolo +
                                " " + utakmica.Domacin.Naziv + " - " + utakmica.Gost.Naziv);
                        }
                    }
                }
            }
        }

        public void PrikaziVazeceZaKlub(Klub klub)
        {
            if (!_mementos.Exists(m => m.StanjeVazeci() == true))
            {
                Console.WriteLine("Nije postavljen važeći raspored!\n");
                return;
            }
            else 
            {
                foreach (var memento in this._mementos)
                {
                    if (memento.StanjeVazeci() == true)
                    {
                        var utakmice = memento.GetUtakmice().Where(u => u.Domacin == klub || u.Gost == klub).ToList();
                        if (utakmice != null)
                        {
                            foreach (Utakmica utakmica in utakmice)
                            {
                                Console.WriteLine(memento.GetRaspored() + " " + memento.GetDatum() + " " + utakmica.Kolo +
                                    " " + utakmica.Domacin.Naziv + " - " + utakmica.Gost.Naziv);
                            }
                        }
                    }
                }
            }
        }

        public void PrikaziVazeceZaKolo(int kolo)
        {
            if (!_mementos.Exists(m => m.StanjeVazeci() == true))
            {
                Console.WriteLine("Nije postavljen važeći raspored!\n");
                return;
            }
            else 
            {
                foreach (var memento in this._mementos)
                {
                    if (memento.StanjeVazeci() == true)
                    {
                        var utakmice = memento.GetUtakmice().Select(m => m as Utakmica).Where(u => u.Kolo == kolo).ToList();
                        if (utakmice != null)
                        {
                            foreach (Utakmica utakmica in utakmice)
                            {
                                Console.WriteLine(memento.GetRaspored() + " " + memento.GetDatum() + " " + utakmica.Kolo +
                                    " " + utakmica.Domacin.Naziv + " - " + utakmica.Gost.Naziv);
                            }
                        }
                    }
                }
            }
        }
    }
}
