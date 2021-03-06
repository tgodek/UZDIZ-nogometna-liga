using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Pricuva : State
    {
        public string GetState()
        {
            return "PRICUVA";
        }

        public bool IgracUIgri()
        {
            return false;
        }

        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(new Igra());
        }

        public void OnIskljucenje(Igrac igrac)
        {
        }

        public void OnPostava(Igrac igrac, string postava)
        {
        }
    }
}
