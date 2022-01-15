using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Idle : State
    {
        public string GetState()
        {
            return "IDLE";
        }

        public bool IgracUIgri()
        {
            return false;
        }

        public void OnPostava(Igrac igrac, string postava)
        {
            if (postava == "S")
                igrac.SetState(new Igra());
            if(postava == "P")
                igrac.SetState(new Pricuva());
        }

        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(this);
        }

        public void OnIskljucenje(Igrac igrac)
        {
        }
    }
}
