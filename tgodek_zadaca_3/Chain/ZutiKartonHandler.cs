using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    public class ZutiKartonHandler : AbstractHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 10 && dogadaj.Igrac.IgracUIgri())
            {
                if (dogadaj.Igrac.ZutiKarton == 1 && dogadaj.Igrac.DrugiZutiKarton == 0)
                {
                    dogadaj.Igrac.DrugiZutiKarton++;
                    dogadaj.Klub.DrugiZutiKarton++;
                    dogadaj.Igrac.OnIskljucenje();
                }
                if (dogadaj.Igrac.ZutiKarton == 0)
                {
                    dogadaj.Igrac.ZutiKarton++;
                    dogadaj.Klub.ZutiKarton++;
                }
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
