using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Zamjenjen : State
    {
        public string GetState()
        {
            return "ZAMJENJEN";
        }

        public bool IgracUIgri()
        {
            return false;
        }

        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(this);
        }

        public void OnIskljucenje(Igrac igrac)
        {
        }

        public void OnPostava(Igrac igrac, string postava)
        {
        }
    }
}
