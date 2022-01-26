using System;
using System.Collections.Generic;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    class Originator
    {
        int broj;

        DateTime datum;

        List<Utakmica> utakmice;

        public int Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public List<Utakmica> Utakmice
        {
            get { return utakmice; }
            set { utakmice = value; }
        }

        public Raspored SaveMemento() 
        {
            return new Raspored(broj, datum, utakmice);
        }

        public void RestoreMemento(Raspored raspored) 
        {
            Broj = raspored.GetBroj();
            Datum = raspored.GetDatum();
            Utakmice = raspored.GetUtakmice();
            Console.WriteLine($"Raspored {Broj} postavljen kao važeći!");
        }
    }
}
