using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Util
{
  
    class GeneralUtil
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
        
        public static List<string> ListaDozvoljenihZastavica()
        {
            return _listaDozvoljenihZastavica;
        }

        public static Enum MapirajZastavicu(string zastavica)
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
