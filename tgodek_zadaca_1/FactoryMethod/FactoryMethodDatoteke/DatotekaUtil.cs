using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ucitavanje_datoteka
{
    internal enum UlazniParametri
    {
        K,
        I,
        U,
        S,
        D,
        NU,
        NS,
        ND
    }

    internal class DatotekaUtil
    {
        private static List<string> _listaDozvoljenihZastavica = new List<string> { "d", "i", "k", "s", "u" };
        private static List<string> _listaDozvoljenihNaredbi = new List<string> { "NU","NS","ND" };

        internal static List<string> DohvatiDozvoljeneZastavice() => _listaDozvoljenihZastavica;
        internal static List<string> DohvatiDozvoljeneNaredbe() => _listaDozvoljenihNaredbi;
       

        internal static List<string> ReadFile(string imeDatoteke)
        {
            var listaVrijednosti = new List<String>();
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
                else
                {
                    postojiDatoteka = true;
                }
            }
            return postojiDatoteka;
        }

       

        internal static Enum MapirajZastavicu(string zastavica)
        {
            switch (zastavica)
            {
                case "k": return UlazniParametri.K;
                case "i": return UlazniParametri.I;
                case "u": return UlazniParametri.U;
                case "s": return UlazniParametri.S;
                case "d": return UlazniParametri.D;
                case "NU": return UlazniParametri.NU;
                case "NS": return UlazniParametri.NS;
                case "ND": return UlazniParametri.ND;
                default: return null;
            }
        }
    }
}
