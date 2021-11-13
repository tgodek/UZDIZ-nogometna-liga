using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Util
{
    class GeneralUtil
    {
        private static List<string> _listaDozvoljenihZastavica = new List<string> { "d", "i", "k", "s", "u" };
        
        public static List<string> ListaDozvoljenihZastavica()
        {
            return _listaDozvoljenihZastavica;
        }



    }
}
