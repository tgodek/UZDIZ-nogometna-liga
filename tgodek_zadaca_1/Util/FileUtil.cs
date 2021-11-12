using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tgodek_zadaca_1.Util
{
    class FileUtil
    {
        public static List<string> ReadFile(string imeDatoteke)
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

        public static bool DatotekeIspravne(Dictionary<string, string> datoteke)
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
