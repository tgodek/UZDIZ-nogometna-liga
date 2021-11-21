using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_1.Composite;
using tgodek_zadaca_1.FactoryMethod.Datoteke;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var trener = new Trener("Pero", "Peric");
            var trener2 = new Trener("Ivo", "Ivic");
            var klub1 = new Klub("SL", "Slaven Belupo", trener);
            var klub2 = new Klub("D", "Dinamo", trener2);
            var igrac = new Igrac(klub1, "Tomislav Godek", Pozicija.LB, DateTime.Today);
            var igrac2 = new Igrac(klub2, "Luka Jakovic", Pozicija.DN, DateTime.Today);

            var ucitavacDatoteka = UcitavacDatoteka.DohvatiUcitavacDatoteka();
            
            if (ucitavacDatoteka.UcitajDatoteke(args))
            {
                Meni();
            }
            else 
            {
                Console.WriteLine("Učitavanje prvenstva je neuspješno");
            }
        }

        private static void Meni()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            while (true)
            {
                Console.WriteLine("\nUnesite 'exit' za izlazak");
                Console.Write("Vaš odabir: ");
                var unos = Console.ReadLine();
                var vrijednosti = unos.Split(" ");
                var builder = new KonkretniIzbornik();

                if (vrijednosti[0] == "exit")
                {
                    break;
                }
                else
                {
                    var izbornik = KonstruirajIzbornik(vrijednosti, builder);
                    if(izbornik is Izbornik)
                        prvenstvo.IspisLjestvice(izbornik);
                    else
                        Console.WriteLine("Neispravni unos");
                }
            }
        }

      

        private static Izbornik KonstruirajIzbornik(string[] vrijednosti, KonkretniIzbornik builder)
        {
            int kolo;
            if (vrijednosti.Length == 3 && vrijednosti[0] == "R" &&
                Int32.TryParse(vrijednosti[2], out kolo))
            {
                builder.DodajZastavicu(vrijednosti[0])
                    .DodajKlub(vrijednosti[1])
                    .DodajKolo(kolo);
                return builder.Build();
            }
            else if (vrijednosti.Length == 2 &&
                (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K") &&
                Int32.TryParse(vrijednosti[1], out kolo))
            {
                builder.DodajZastavicu(vrijednosti[0])
                    .DodajKolo(kolo);
                return builder.Build();
            }
            else if (vrijednosti.Length == 2 && (vrijednosti[0] == "R"))
            {
                builder.DodajZastavicu(vrijednosti[0])
                    .DodajKlub(vrijednosti[1]);
                return builder.Build();
            }

            else if (vrijednosti.Length == 1 &&
                (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K" || vrijednosti[0] == "R"))
            {
                builder.DodajZastavicu(vrijednosti[0]);
                return builder.Build();
            }
            else
            {
                return null;
            }
        }
    }
}


