﻿using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Builder
{
    class KonkretniDogadaj : IDogadaj
    {
        Dogadaj _dogadaj = new Dogadaj();

        public KonkretniDogadaj()
        {
            Reset();
        }
        public void DodajOsnovno(Utakmica utakmica, string minute, int vrsta)
        {
            this._dogadaj.Utakmica = utakmica;
            this._dogadaj.Min = minute;
            this._dogadaj.Vrsta = vrsta;
        }

        public void DodajKlubIIgraca(Klub klub, Igrac igrac)
        {
            this._dogadaj.Klub = klub;
            this._dogadaj.Igrac = igrac;
        }

        public void DodajZamjenu(Igrac zamjena)
        {
            this._dogadaj.Zamjena = zamjena;
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
