using facade;
using System;
using System.Text;

namespace tgodek_zadaca_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            var ucitavacDatoteka = UcitavacDatotekaFacade.DohvatiUcitavacDatoteka();
            ucitavacDatoteka.UcitajDatoteke(args);
            if (ucitavacDatoteka.DatotekaIgracUcitan && ucitavacDatoteka.DatotekaIgracUcitan) 
                Meni();
            else 
                Console.WriteLine("Učitavanje prvenstva je neuspješno! Potrebno je učitati sve obavezne datoteke.");
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
                    PokusajUcitatiDodatneDatoteke(vrijednosti);
                    var izbornik = KonstruirajIzbornik(vrijednosti, builder);
                    if(izbornik is Izbornik)
                        prvenstvo.IspisLjestvice(izbornik);
                }
            }
        }

        private static void PokusajUcitatiDodatneDatoteke(string[] vrijednosti)
        {
            if (vrijednosti.Length == 2 && (vrijednosti[0] == "NU" || vrijednosti[0] == "NS" || vrijednosti[0] == "ND"))
            {
                var ucitavac = UcitavacDatotekaFacade.DohvatiUcitavacDatoteka();
                ucitavac.UcitajDatoteke(vrijednosti);
            }
        }

        private static Izbornik KonstruirajIzbornik(string[] vrijednosti, KonkretniIzbornik builder)
        {
            int kolo;
            int broj;
            if (vrijednosti.Length == 3 && vrijednosti[0] == "R" &&
                Int32.TryParse(vrijednosti[2], out kolo) && !Int32.TryParse(vrijednosti[1], out broj))
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
            else if (vrijednosti.Length == 2 && (vrijednosti[0] == "R") && !Int32.TryParse(vrijednosti[1], out broj))
            {
                builder.DodajZastavicu(vrijednosti[0])
                    .DodajKlub(vrijednosti[1]);
                return builder.Build();
            }

            else if (vrijednosti.Length == 1 &&
                (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K"))
            {
                builder.DodajZastavicu(vrijednosti[0]);
                return builder.Build();
            }
            
            else
                return null;
        }
    }
}


