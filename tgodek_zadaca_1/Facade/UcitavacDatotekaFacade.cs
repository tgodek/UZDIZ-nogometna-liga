using System;
using System.Collections.Generic;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1.FactoryMethod.Datoteke
{
    public class UcitavacDatotekaFacade
    {
        private static UcitavacDatotekaFacade instanca;
        private UcitavacDatotekaFacade()
        {
        }

        public static UcitavacDatotekaFacade DohvatiUcitavacDatoteka()
        {
            if (instanca == null)
            {
                instanca = new UcitavacDatotekaFacade();
            }
            return instanca;
        }

        public bool UcitajDatoteke(string[] argumenti)
        {
            var popisDatoteka = ObradiPocetneParametre(argumenti);
            UcitavacDatotekaFactory fileLoaderFactory = new UcitavacDatotekaFactory();

            bool ucitavanjeUspjesno = false;
            if (DatotekaUtil.DatotekeIspravne(popisDatoteka))
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
            var zastavice = DatotekaUtil.ListaDozvoljenihZastavica();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-") && zastavice.Exists(zastavica => args[i].Contains(zastavica)))
                {
                    var zastavica = args[i].Trim('-');
                    try
                    {
                        var mapiranaZastavica = DatotekaUtil.MapirajZastavicu(zastavica);
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
