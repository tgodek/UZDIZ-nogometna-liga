using System;
using System.Collections.Generic;
using ucitavanje_datoteka;

namespace facade
{
    public class UcitavacDatotekaFacade
    {
        private static UcitavacDatotekaFacade instanca;
        private UcitavacDatotekaFactory ucitavacDatoteka;

        public bool DatotekaKlubUcitan { get; private set; } 
        public bool DatotekaIgracUcitan { get; private set; }
        public bool DatotekaUtakmicaUcitan { get; private set; }
        public bool DatotekaSastavUcitan { get; private set; }
        public bool DatotekaDogadajUcitan { get; private set; }

        private UcitavacDatotekaFacade()
        {
            DatotekaKlubUcitan = false;
            DatotekaIgracUcitan = false;
            DatotekaUtakmicaUcitan = false;
            DatotekaSastavUcitan = false;
            DatotekaDogadajUcitan = false;
        }

        public static UcitavacDatotekaFacade DohvatiUcitavacDatoteka()
        {
            if (instanca == null)
            {
                instanca = new UcitavacDatotekaFacade();
            }
            return instanca;
        }

        public void UcitajDatoteke(string[] argumenti)
        {
            var popisDatoteka = ObradiPocetneParametre(argumenti);
            ucitavacDatoteka = new UcitavacDatotekaFactory();

            if (DatotekaUtil.DatotekeIspravne(popisDatoteka))
            {
                foreach (var datoteka in popisDatoteka)
                {
                    if (datoteka.Key is UlazniParametri.K)
                    {
                        var rezultat = ucitavacDatoteka.DohvatiPodatke("k");
                        rezultat.UcitajPodatke(datoteka.Value);
                        DatotekaKlubUcitan = true;
                    }
                    if (datoteka.Key is UlazniParametri.I && DatotekaKlubUcitan)
                    {
                        var rezultat = ucitavacDatoteka.DohvatiPodatke("i");
                        rezultat.UcitajPodatke(datoteka.Value);
                        DatotekaIgracUcitan = true;
                    }
                    if ((datoteka.Key is UlazniParametri.U || datoteka.Key is UlazniParametri.NU) && DatotekaIgracUcitan)
                    {
                        var rezultat = ucitavacDatoteka.DohvatiPodatke("u");
                        rezultat.UcitajPodatke(datoteka.Value);
                        DatotekaUtakmicaUcitan = true;
                    }
                    if ((datoteka.Key is UlazniParametri.S || datoteka.Key is UlazniParametri.NS) && DatotekaUtakmicaUcitan)
                    {
                        var rezultat = ucitavacDatoteka.DohvatiPodatke("s");
                        rezultat.UcitajPodatke(datoteka.Value);
                        DatotekaSastavUcitan = true;
                    }
                    if ((datoteka.Key is UlazniParametri.D || datoteka.Key is UlazniParametri.ND) && DatotekaSastavUcitan)
                    {
                        var rezultat = ucitavacDatoteka.DohvatiPodatke("d");
                        rezultat.UcitajPodatke(datoteka.Value);
                        DatotekaDogadajUcitan = true;
                    }
                }
            }
        }

        private SortedList<Enum, string> ObradiPocetneParametre(string[] args)
        {
            SortedList<Enum, string> hash = new SortedList<Enum, string>();
            var zastavice = DatotekaUtil.DohvatiDozvoljeneZastavice();
            var naredbe = DatotekaUtil.DohvatiDozvoljeneNaredbe();

            for (int i = 0; i < args.Length; i++)
            {
                if ((naredbe.Exists(naredba => args[i].Contains(naredba) && DatotekaKlubUcitan && DatotekaIgracUcitan) 
                    || (args[i].StartsWith("-") && zastavice.Exists(zastavica => args[i].Contains(zastavica)))))
                {
                    string zastavica = args[i];
                    if(args[i].StartsWith("-"))
                        zastavica = args[i].Trim('-');
                    try
                    {
                        var mapiranaZastavica = DatotekaUtil.MapirajZastavicu(zastavica);
                        if (i < args.Length - 1)
                            hash.Add(mapiranaZastavica, args[i + 1]);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Pogreška prilikom obrade ulaznih parametara!\n Datoteka s zadnjom dupliciranom zastavicom se izbacuje!");
                        break;
                    }
                }
            }
            return hash;
        }
    }
}
