using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Visitor;

namespace tgodek_zadaca_3.Composite
{
    public class Dogadaj : INogometnaLiga
    {
        public Utakmica Utakmica { get; set; }
        public string Min { get; set; }
        public int Vrsta { get; set; }
        public Klub Klub { get; set; }
        public Igrac Igrac { get; set; }
        public Igrac Zamjena { get; set; }

        public void Accept(IVisit operacija)
        {
            operacija.Visit(this);
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            return null;
        }
    }
}
