using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    class CrveniKartonHandler : AbstractHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 11 && dogadaj.Igrac.IgracUIgri())
            {
                if (dogadaj.Igrac.CrveniKarton == 0)
                {
                    dogadaj.Igrac.CrveniKarton++;
                    dogadaj.Klub.CrveniKarton++;
                    dogadaj.Igrac.OnIskljucenje();
                    
                }
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
