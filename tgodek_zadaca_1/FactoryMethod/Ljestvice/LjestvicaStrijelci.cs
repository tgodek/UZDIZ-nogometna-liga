using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Model;

namespace tgodek_zadaca_1.FactoryMethod.Ljestvice
{
    public class LjestvicaStrijelci : ILjestvica
    {
        private int Kolo { get; set; }

        public LjestvicaStrijelci(int kolo) 
        {
            this.Kolo = kolo;
        }

        public void Ispis()
        {
            /*
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var dogadaji = prvenstvo.SviDogadaji();
            var igraci = prvenstvo.SviIgraci();
            var utakmice = prvenstvo.SveUtakmice();

            var zadnjaUtakmica = utakmice.FindLast(u => u.Kolo == Kolo);

            if (zadnjaUtakmica != null && Kolo != 0)
            {
                foreach (var dogadaj in dogadaji)
                {
                    foreach (var igrac in igraci)
                    {
                        if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2 || dogadaj.Vrsta == 3) && (dogadaj.Igrac == igrac.Ime) && (dogadaj.Broj <= zadnjaUtakmica.Broj))
                        {
                            igrac.Golovi += 1;
                        }
                    }
                }

                Console.WriteLine("\n--------------------------------- STRIJELCI -----------------------------------");
                Console.WriteLine("| {0,5} {1,20} {2,20} {3,13} {4,12} |", "Golovi", "Igrac", "Pozicija", "Klub", "Roden");
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (var igrac in igraci)
                {
                    if (igrac.Golovi > 0)
                    {
                        Console.WriteLine("{0,5} {1,25} {2,15} {3,15} {4,15}", igrac.Golovi, igrac.Ime, igrac.Pozicija, igrac.Klub, igrac.Datum.ToString("dd/MM/yyyy"));
                        igrac.Golovi = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("Kolo ne postoji");
            }*/
        }
    }

}
