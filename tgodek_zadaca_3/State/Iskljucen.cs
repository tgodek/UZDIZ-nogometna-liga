using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Iskljucen : State
    {
        public string GetState()
        {
            return "ISKLJUCEN";
        }

        public bool IgracUIgri()
        {
            return false;
        }

        public void OnIskljucenje(Igrac igrac)
        {
            throw new NotImplementedException();
        }

        public void OnPostava(Igrac igrac, string postava)
        {
            throw new NotImplementedException();
        }

        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(this);
        }
    }
}
