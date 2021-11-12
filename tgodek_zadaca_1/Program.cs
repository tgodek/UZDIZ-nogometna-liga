using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> flags = new List<string>() { "d", "i", "k", "s", "u" };
            Dictionary<string, string> hash = new Dictionary<string, string>();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-") && flags.Exists(flag => args[i].Contains(flag)))
                {
                    var flag = args[i].Trim('-');
                    try
                    {
                        if (i < args.Length - 1)
                            hash.Add(flag, args[i + 1]);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Postoje duplikati u argumentima!");
                        break;
                    }
                }
            }

            if (UcitavanjeUspjesno(hash))
            {
                Meni();
            }
            else 
            {
                Console.WriteLine("Ucitavanje prvenstva je neuspjesno");
            }
        }

        private static void Meni()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            bool ponovno = true;
            while (ponovno)
            {
                Console.WriteLine("\nUnesite 'exit' za izlazak");
                Console.Write("Vaš odabir: ");
                var unos = Console.ReadLine();
                var vrijednosti = unos.Split(" ");

                if (vrijednosti[0] == "exit")
                {
                    ponovno = false;
                    break;
                }
                else if (vrijednosti.Length == 3)
                {
                    Console.WriteLine(vrijednosti.Length);
                    var zastavica = vrijednosti[0];
                    int kolo;
                    if ((zastavica == "R") &&
                        Int32.TryParse(vrijednosti[2], out kolo))
                    {
                        var builder = new KonkretniIzbornik();
                        builder.DodajZastavicu(zastavica).DodajKlub(vrijednosti[1]).DodajKolo(kolo);
                        prvenstvo.IspisLjestvice(builder.Build());
                    }
                }
                else if (vrijednosti.Length == 2 &&
                    (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K"))
                {
                    var zastavica = vrijednosti[0];
                    int kolo;
                    if (Int32.TryParse(vrijednosti[1], out kolo))
                    {
                        var builder = new KonkretniIzbornik();
                        builder.DodajZastavicu(zastavica).DodajKolo(kolo);
                        prvenstvo.IspisLjestvice(builder.Build());
                    }
                }
                else if (vrijednosti.Length == 2 && (vrijednosti[0] == "R"))
                {
                    var zastavica = vrijednosti[0];
                    var klub = vrijednosti[1];
                    var builder = new KonkretniIzbornik();
                    builder.DodajZastavicu(zastavica).DodajKlub(klub);
                    prvenstvo.IspisLjestvice(builder.Build());
                }

                else if (vrijednosti.Length == 1 &&
                    (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K" || vrijednosti[0] == "R"))
                {
                    var zastavica = vrijednosti[0];
                    var builder = new KonkretniIzbornik();
                    builder.DodajZastavicu(zastavica);
                    prvenstvo.IspisLjestvice(builder.Build());
                }
                else
                {
                    Console.WriteLine("Neispravan unos");
                }
            }
        }

        private static bool UcitavanjeUspjesno(Dictionary<string, string> hash)
        {
            bool ucitajPrvenstvo = false;
            if (hash.Keys.Count == 5)
            {
                if (FileUtil.DatotekeIspravne(hash))
                {
                    ucitajPrvenstvo = true;
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
                }
                else
                {
                    Console.WriteLine("Molimo unesite sve parametre");
                    ucitajPrvenstvo = false;
                }
            }
            return ucitajPrvenstvo;
        }
    }
}


