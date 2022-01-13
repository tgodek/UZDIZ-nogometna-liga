using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Igra : State
    {
        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(new Zamjenjen());
        }
    }
}
