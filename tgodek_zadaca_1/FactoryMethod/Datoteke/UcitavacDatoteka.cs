using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1.FactoryMethod.Datoteke
{
    class UcitavacDatoteka
    {

        private static UcitavacDatoteka instanca;
        private UcitavacDatoteka()
        {
        }

        public static UcitavacDatoteka DohvatiUcitavacDatoteka()
        {
            if (instanca == null)
            {
                instanca = new UcitavacDatoteka();
            }
            return instanca;
        }

        public bool UcitajDatoteke(string[] argumenti)
        {
            var popisDatoteka = ObradiPocetneParametre(argumenti);
            FileLoaderFactory fileLoaderFactory = new FileLoaderFactory();

            bool ucitavanjeUspjesno = false;
            if (FileUtil.DatotekeIspravne(popisDatoteka))
            {
                ucitavanjeUspjesno = true;
                foreach (var datoteka in popisDatoteka)
                {
                    var rezultat = fileLoaderFactory.DohvatiPodatke(datoteka.Key.ToString().ToLower());
                    rezultat.UcitajPodatke(datoteka.Value);
                }
            }
            return ucitavanjeUspjesno;
        }

        private static SortedList<Enum, string> ObradiPocetneParametre(string[] args)
        {
            SortedList<Enum, string> hash = new SortedList<Enum, string>();
            var zastavice = GeneralUtil.ListaDozvoljenihZastavica();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-") && zastavice.Exists(zastavica => args[i].Contains(zastavica)))
                {
                    var zastavica = args[i].Trim('-');
                    try
                    {
                        var mapiranaZastavica = GeneralUtil.MapirajZastavicu(zastavica);
                        if (i < args.Length - 1)
                            hash.Add(mapiranaZastavica, args[i + 1]);
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
    }
}
