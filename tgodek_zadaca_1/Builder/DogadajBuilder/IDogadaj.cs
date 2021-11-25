using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Builder
{
    interface IDogadaj
    {
        public void DodajOsnovno(Utakmica utakmica, string minute, int vrsta);
        public void DodajKlubIIgraca(Klub klub, Igrac igrac);
        public void DodajZamjenu(Igrac zamjena);
    }
}
