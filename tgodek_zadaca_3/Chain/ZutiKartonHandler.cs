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
            if (dogadaj.Vrsta == 10)
            {
                //TODO: Logika za zuti kartn
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
