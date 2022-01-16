using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    class AutogolHandler : AbstractHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 3)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                    dogadaj.Utakmica.RezultatGost += 1;

                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                    dogadaj.Utakmica.RezultatDomacin += 1;
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
