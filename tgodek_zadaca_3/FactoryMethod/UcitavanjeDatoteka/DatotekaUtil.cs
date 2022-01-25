using System;
using System.Collections.Generic;
using System.IO;

namespace ucitavanje_datoteka
{
    internal enum OsnovniParametri
    {
        K, I, U, S, D, NU, NS, ND
    }

    internal class DatotekaUtil
    {
        private static readonly List<string> listaDozvoljenihZastavica = new List<string> { "d", "i", "k", "s", "u" };
        private static readonly List<string> listaDozvoljenihNaredbi = new List<string> { "NU", "NS", "ND" };

        internal static List<string> DohvatiDozvoljeneZastavice() => listaDozvoljenihZastavica;
        internal static List<string> DohvatiDozvoljeneNaredbe() => listaDozvoljenihNaredbi;
       
        internal static List<string> UcitajDatoteku(string imeDatoteke)
        {
            var listaVrijednosti = new List<string>();
            var citac = new StreamReader(imeDatoteke);
            citac.ReadLine();
            string line;
            while ((line = citac.ReadLine()) != null)
            {
                listaVrijednosti.Add(line);
            }
            citac.Close();
            return listaVrijednosti;
        }

        internal static bool DatotekeIspravne(SortedList<Enum, string> datoteke)
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
                else postojiDatoteka = true;
            }
            return postojiDatoteka;
        }

        internal static Enum MapirajZastavicu(string zastavica)
        {
            return zastavica switch
            {
                "k" => OsnovniParametri.K,
                "i" => OsnovniParametri.I,
                "u" => OsnovniParametri.U,
                "s" => OsnovniParametri.S,
                "d" => OsnovniParametri.D,
                "NU" => OsnovniParametri.NU,
                "NS" => OsnovniParametri.NS,
                "ND" => OsnovniParametri.ND,
                _ => null,
            };
        }
    }
}
