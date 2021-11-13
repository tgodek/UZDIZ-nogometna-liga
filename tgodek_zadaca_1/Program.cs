using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (UcitavanjeUspjesno(PocetniParametni(args)))
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

        private static Dictionary<string, string> PocetniParametni(string[] args)
        {
            Dictionary<string, string> hash = new Dictionary<string, string>();
            var zastavice = GeneralUtil.ListaDozvoljenihZastavica();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-") && zastavice.Exists(zastavica => args[i].Contains(zastavica)))
                {
                    var zastavica = args[i].Trim('-');
                    try
                    {
                        if (i < args.Length - 1)
                            hash.Add(zastavica, args[i + 1]);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Postoje duplikati u argumentima!");
                        break;
                    }
                }
            }
            return hash;
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

        private static bool UcitavanjeUspjesno(Dictionary<string, string> hash)
        {
            bool ucitajPrvenstvo = false;
            if (hash.Keys.Count == 5 && FileUtil.DatotekeIspravne(hash))
            {
                FileLoaderFactory fileReaderFactory = new FileLoaderFactory();
                   
                var klubovi = fileReaderFactory.DohvatiPodatke(hash.FirstOrDefault(x => x.Key == "k").Key);
                klubovi.UcitajPodatke(hash.FirstOrDefault(x => x.Key == "k").Value);
                var igraci = fileReaderFactory.DohvatiPodatke(hash.FirstOrDefault(x => x.Key == "i").Key);
                igraci.UcitajPodatke(hash.FirstOrDefault(x => x.Key == "i").Value);
                var utakmice = fileReaderFactory.DohvatiPodatke(hash.FirstOrDefault(x => x.Key == "u").Key);
                utakmice.UcitajPodatke(hash.FirstOrDefault(x => x.Key == "u").Value);
                var sastavUtakmice = fileReaderFactory.DohvatiPodatke(hash.FirstOrDefault(x => x.Key == "s").Key);
                sastavUtakmice.UcitajPodatke(hash.FirstOrDefault(x => x.Key == "s").Value);
                var dogadaji = fileReaderFactory.DohvatiPodatke(hash.FirstOrDefault(x => x.Key == "d").Key);
                dogadaji.UcitajPodatke(hash.FirstOrDefault(x => x.Key == "d").Value);
                
                ucitajPrvenstvo = true;
            }
            else
            {
                Console.WriteLine("Molimo unesite sve parametre");
                ucitajPrvenstvo = false;
            }
            return ucitajPrvenstvo;
        }
    }
}


