using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                var zastavica = vrijednosti[0].ToUpper();
                if (zastavica == "EXIT")
                { 
                    ponovno = false; 
                    break;
                }

                if (vrijednosti.Length <= 2)
                {

                    if (zastavica == "T" || zastavica == "S" || zastavica == "K")
                    {
                        if (vrijednosti.Length == 2)
                        {
                            Int32 broj;
                            if (Int32.TryParse(vrijednosti[1], out broj))
                            {
                                prvenstvo.IspisLjestvice(zastavica, broj);
                            }
                            else
                            {
                                Console.WriteLine("Drugi parametar mora biti broj!");
                            }
                        }
                        else
                        {
                            prvenstvo.IspisLjestvice(zastavica);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Prvi parametar je krivi!");
                    }
                }
                else if (vrijednosti.Length == 3 && zastavica == "R")
                {
                    Int32 broj;
                    if (Int32.TryParse(vrijednosti[2], out broj))
                    {
                        prvenstvo.IspisLjestviceKlubova(vrijednosti[1], broj);
                    }
                    else
                    {
                        Console.WriteLine("Treći parametar mora biti broj!");
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }

            }
          
        }

        private static bool UcitavanjeUspjesno(Dictionary<string, string> hash)
        {
            bool ucitajPrvenstvo = false;
            if (hash.Keys.Count == 5)
            {
                if (DatotekeIspravne(hash))
                {
                    ucitajPrvenstvo = true;
                    FileLoaderFactory fileReaderFactory = new FileLoaderFactory();
                    
                    foreach (var value in hash)
                    {
                        if (value.Key == "k")
                        {
                            var klubovi = fileReaderFactory.DohvatiPodatke(value.Key);
                            klubovi.UcitajPodatke(value.Value);
                        }

                        if (value.Key == "i")
                        {
                            var igraci = fileReaderFactory.DohvatiPodatke(value.Key);
                            igraci.UcitajPodatke(value.Value);
                        }
                      
                        if (value.Key == "u")
                        {
                            var utakmice = fileReaderFactory.DohvatiPodatke(value.Key);
                            utakmice.UcitajPodatke(value.Value);
                        }

                        if (value.Key == "s")
                        {
                            var sastavUtakmice = fileReaderFactory.DohvatiPodatke(value.Key);
                            sastavUtakmice.UcitajPodatke(value.Value);
                        }

                        if (value.Key == "d")
                        {
                            var sastavUtakmice = fileReaderFactory.DohvatiPodatke(value.Key);
                            sastavUtakmice.UcitajPodatke(value.Value);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Molimo unesite sve parametre");
                    ucitajPrvenstvo = false;
                }
            }
            return ucitajPrvenstvo;
        }


        static private bool DatotekeIspravne(Dictionary<string, string> datoteke)
        {
            bool postojiDatoteka = false;
            foreach (var datoteka in datoteke)
            {
                if (!File.Exists(datoteka.Value))
                {
                    Console.WriteLine("Datoteka " + datoteka.Value + " ne postoji!");
                    postojiDatoteka = false;
                    break;
                }
                else
                {
                    postojiDatoteka = true;
                }
            }
            return postojiDatoteka;
        }
    }
}


