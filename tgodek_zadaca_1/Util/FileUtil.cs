using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tgodek_zadaca_1.Util
{
    class FileUtil
    {
        static public List<string> ReadFile(string imeDatoteke)
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
    }
}
