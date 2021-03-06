using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Builder.DogadajBuilder
{
    interface IDogadaj
    {
        public IDogadaj DodajOsnovno(Utakmica utakmica, string minute, int vrsta);
        public IDogadaj DodajKlubIIgraca(Klub klub, Igrac igrac);
        public IDogadaj DodajZamjenu(Igrac zamjena);
    }
}
