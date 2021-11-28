﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.FactoryMethod.Ljestvice
{
    public class LjestvicaFactory
    {
        public ILjestvica DohvatiLjestvicu(string oznaka, int kolo)
        {
            if (oznaka == "T")
            {
            }
            if (oznaka == "R")
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
