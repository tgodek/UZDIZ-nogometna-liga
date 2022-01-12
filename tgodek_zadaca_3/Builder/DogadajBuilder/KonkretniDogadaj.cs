using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Builder.DogadajBuilder
{
    class KonkretniDogadaj : IDogadaj
    {
        Dogadaj _dogadaj = new Dogadaj();

        public KonkretniDogadaj()
        {
            Reset();
        }
        public IDogadaj DodajOsnovno(Utakmica utakmica, string minute, int vrsta)
        {
            this._dogadaj.Utakmica = utakmica;
            this._dogadaj.Min = minute;
            this._dogadaj.Vrsta = vrsta;
            return this;
        }

        public IDogadaj DodajKlubIIgraca(Klub klub, Igrac igrac)
        {
            this._dogadaj.Klub = klub;
            this._dogadaj.Igrac = igrac;
            return this;
        }

        public IDogadaj DodajZamjenu(Igrac zamjena)
        {
            this._dogadaj.Zamjena = zamjena;
            return this;
        }

        private void Reset()
        {
            this._dogadaj = new Dogadaj();
        }

        public Dogadaj Build() 
        {
            Dogadaj dogadaj = this._dogadaj;
            this.Reset();
            return dogadaj;
        }
    }
}
