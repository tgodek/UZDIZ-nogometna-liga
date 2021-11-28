using facade;
using System;
using tgodek_zadaca_1.Composite;
using tgodek_zadaca_1.Visitor;

namespace tgodek_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var ucitavacDatoteka = UcitavacDatotekaFacade.DohvatiUcitavacDatoteka();

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


