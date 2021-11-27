using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Visitor;

namespace tgodek_zadaca_1.Composite
{
    public class Dogadaj : INogometnaLiga
    {
        public Utakmica Utakmica { get; set; }
        public string Min { get; set; }
        public int Vrsta { get; set; }
        public Klub Klub { get; set; }
        public Igrac Igrac { get; set; }
        public Igrac Zamjena { get; set; }

        public void Accept(IOperation operacija)
        {
            operacija.Visit(this);
        }

        public void DetaljiKomponente()
        {
            if(Vrsta == 0 || Vrsta == 99)
                Console.WriteLine("  |-- Utakmica: {0}, Minuta: {1}, Vrsta: {2}",
                Utakmica.Broj, Min, Vrsta);
            if (Vrsta == 1 || Vrsta == 2 || Vrsta == 3 || Vrsta == 10 || Vrsta == 11)
                Console.WriteLine("  |-- Utakmica: {0}, Minuta: {1}, Vrsta: {2}, Klub: {3}, Igrac: {4}",
                Utakmica.Broj, Min, Vrsta, Klub.Naziv, Igrac.Ime);
            if (Vrsta == 20)
                Console.WriteLine("  |-- Utakmica: {0}, Minuta: {1}, Vrsta: {2}, Klub: {3}, Igrac: {4}, Zamjena: {5}",
                Utakmica.Broj, Min, Vrsta, Klub.Naziv, Igrac.Ime, Zamjena.Ime);
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            return null;
        }
    }
}
