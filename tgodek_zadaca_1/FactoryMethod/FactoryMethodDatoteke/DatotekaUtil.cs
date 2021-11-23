using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ucitavanje_datoteka
{
    class DatotekaUtil
    {
        enum UlazniParametri
        {
            K,
            I,
            U,
            S,
            D
        }

        private static List<string> _listaDozvoljenihZastavica = new List<string> { "d", "i", "k", "s", "u" };

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

        internal static List<string> ListaDozvoljenihZastavica()
        {
            return _listaDozvoljenihZastavica;
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
                default: return null;
            }
        }
    }
}
