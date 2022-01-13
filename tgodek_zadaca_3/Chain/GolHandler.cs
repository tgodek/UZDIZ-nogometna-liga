using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    class GolHandler : AbstractHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Igrac.IgracUIgri()) 
            {
                dogadaj.Igrac.BrojPogodaka++;
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
