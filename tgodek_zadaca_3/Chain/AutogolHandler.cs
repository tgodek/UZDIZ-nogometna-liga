using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    class AutogolHandler : BaseHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 3)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka) 
                {
                    dogadaj.Utakmica.RezultatGost += 1;
                    dogadaj.Utakmica.Domacin.BrojPrimljenihGolova += 1;
                    dogadaj.Utakmica.Gost.BrojDanihGolova += 1;

                }

                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka) 
                {
                    dogadaj.Utakmica.RezultatDomacin += 1;
                    dogadaj.Utakmica.Domacin.BrojDanihGolova += 1;
                    dogadaj.Utakmica.Gost.BrojPrimljenihGolova += 1;
                }
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
