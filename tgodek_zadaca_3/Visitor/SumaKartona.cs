using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3.Visitor
{
    public class SumaKartona
    {
        public int UkZutih { get; set; }
        public int UkDrugihZutih { get; set; }
        public int UkCrvenih { get; set; }

        public int Ukupno()
        {
            return UkZutih + UkDrugihZutih + UkCrvenih;
        }

        public SumaKartona()
        {
            UkZutih = 0;
            UkDrugihZutih = 0;
            UkCrvenih = 0;
        }
    }
}
