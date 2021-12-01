using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_2.Composite;

namespace tgodek_zadaca_2.Builder.DogadajBuilder
{
    class DogadajDirector
    {
        private IDogadaj _builder;

        public IDogadaj Builder
        {
            set { _builder = value; }
        }

        public void IzradiOsnovniDogadaj(Utakmica utakmica, string minute, int vrsta)
        {
            this._builder.DodajOsnovno(utakmica, minute, vrsta);
          
        }

        public void IzradiDogadajZaIgraca(Utakmica utakmica, string minute, int vrsta, Klub klub, Igrac igrac)
        {
            this._builder.DodajOsnovno(utakmica, minute, vrsta).DodajKlubIIgraca(klub,igrac);
        }

        public void IzradiDogadajZaZamjenu(Utakmica utakmica, string minute, int vrsta, Klub klub, Igrac igrac, Igrac zamjena)
        {
            this._builder.DodajOsnovno(utakmica, minute, vrsta).DodajKlubIIgraca(klub,igrac).DodajZamjenu(zamjena);
        }
    }
}
