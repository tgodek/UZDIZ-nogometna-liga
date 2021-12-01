using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_2.Visitor
{
    class SumaLjestvicePrvenstva
    {
        public int SumaBrojaPobjeda {get; set;}
        public int SumaBrojaNerjesenih {get; set;}
        public int SumaBrojaPoraza {get; set;}
        public int SumaBrojaDanihGolova {get; set;}
        public int SumaBrojaPrimljenihGolova {get; set;}
        public int SumaBrojaBodova {get; set;}

        public SumaLjestvicePrvenstva()
        {
            SumaBrojaPobjeda = 0;
            SumaBrojaNerjesenih = 0;
            SumaBrojaPoraza = 0;
            SumaBrojaDanihGolova = 0;
            SumaBrojaPrimljenihGolova = 0;
            SumaBrojaBodova = 0;
        }
    }
}
