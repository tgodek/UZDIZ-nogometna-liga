using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    class Igra : State
    {
        public string GetState()
        {
            return "IGRA";
        }

        public bool IgracUIgri()
        {
            return true;
        }

        public void OnIskljucenje(Igrac igrac)
        {
            igrac.SetState(new Iskljucen());
        }

        public void OnZamjena(Igrac igrac)
        {
            igrac.SetState(new Zamjenjen());
        }

        public void OnPostava(Igrac igrac, string postava)
        {
        }
    }
}
