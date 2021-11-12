using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Model;

namespace tgodek_zadaca_1.Builder
{
    class KonkretniDogadaj : IBuilder
    {
        Dogadaj _dogadaj = new Dogadaj();

        public KonkretniDogadaj()
        {
            Reset();
        }
        public void DodajOsnovno(int utakmica, string minute, int vrsta)
        {
            this._dogadaj.Broj = utakmica;
            this._dogadaj.Min = minute;
            this._dogadaj.Vrsta = vrsta;
        }

        public void DodajIgracaIKlub(string klub, string igrac)
        {
            this._dogadaj.Klub = klub;
            this._dogadaj.Igrac = igrac;
        }

        public void DodajZamjenu(string zamjena)
        {
            this._dogadaj.Zamjena = zamjena;
        }

        public void Reset()
        {
            this._dogadaj = new Dogadaj();
        }

        public Dogadaj DohvatiDohadaj() 
        {
            Dogadaj dogadaj = this._dogadaj;
            this.Reset();
            return dogadaj;
        }
    }
}
