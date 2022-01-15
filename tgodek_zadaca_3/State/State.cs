using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.StatePattern
{
    public interface State
    {
        void OnZamjena(Igrac igrac);
        void OnPostava(Igrac igrac, string postava);
        void OnIskljucenje(Igrac igrac);
        bool IgracUIgri();
        string GetState();
    }
}
