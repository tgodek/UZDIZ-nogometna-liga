using System;
using System.Text;
using ucitavanje_facade;

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

            if (ucitavacDatoteka.DatotekaIgracUcitan) Meni();
            else Console.WriteLine("Učitavanje prvenstva je neuspješno! Potrebno je učitati sve obavezne datoteke.\n");
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

                var builder = new IzbornikBuilder();
                var direktor = new IzbornikDirektor { Builder = builder };
                direktor.IzradiIzbornik(vrijednosti);
                var izbornik = builder.Build();
                
                if (vrijednosti[0] == "exit") break;
                else if (vrijednosti.Length == 2 && (vrijednosti[0] == "NU" || vrijednosti[0] == "NS" || vrijednosti[0] == "ND")) 
                {
                    var ucitavac = UcitavacDatotekaFacade.DohvatiUcitavacDatoteka();
                    ucitavac.UcitajDatoteke(vrijednosti);
                }
                else prvenstvo.ObradiZahtjev(izbornik);
            }
        }
    }
}


