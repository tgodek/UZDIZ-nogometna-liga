using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Chain
{
    class ZamjenaHandler : AbstractHandler
    {
        public override void ProccessEvent(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 20) 
            {
                dogadaj.Igrac.OnZamjena();
                dogadaj.Zamjena.OnZamjena();
            }
            else base.ProccessEvent(dogadaj);
        }
    }
}
