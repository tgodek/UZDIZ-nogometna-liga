using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Idle : State
    {
        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(this);
        }
    }
}
