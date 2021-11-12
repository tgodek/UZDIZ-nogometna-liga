using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.FactoryMethod;
using tgodek_zadaca_1.FactoryMethod.Ljestvice;

namespace tgodek_zadaca_1.Model
{
    public class LjestvicaFactory
    {
        public ILjestvica DohvatiLjestvicu(string oznaka, int kolo)
        {
            if (oznaka == "T")
            {
            }
            if (oznaka == "K")
            {
                return new LjestvicaKartoni(kolo);

            }
            if (oznaka == "S")
            {
                return new LjestvicaStrijelci(kolo);
            }
            return null;
        }
    }
 
}
