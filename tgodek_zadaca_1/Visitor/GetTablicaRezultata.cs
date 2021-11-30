using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Visitor
{
    class GetTablicaRezultata : IOperation
    {
        private int _kolo;
        private int domacinGolovi { get; set; }
        private int gostGolovi { get; set; }
        private string _oznakaKluba { get; set; }

        public GetTablicaRezultata(string oznakaKluba, int kolo = 0)
        {
            domacinGolovi = 0;
            gostGolovi = 0;
            _kolo = kolo;
            _oznakaKluba = oznakaKluba;
        }

        private void ObradiDogadajZaPogodak(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                    domacinGolovi += 1;
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                    gostGolovi += 1;
            }
            if (dogadaj.Vrsta == 3)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                    gostGolovi += 1;

                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                    domacinGolovi += 1;
            }
        }

        public void Visit(Klub klub)
        {
        }

        public void Visit(Igrac igrac)
        {
        }

        public void Visit(Trener trener)
        {
        }

        public void Visit(Utakmica utakmica)
        {
            if (_kolo == 0)
            {
                if (utakmica.PostojiDogadaj() && (utakmica.Domacin.Oznaka == _oznakaKluba || utakmica.Gost.Oznaka == _oznakaKluba))
                {
                    utakmica.RezultatDomacin = domacinGolovi;
                    utakmica.RezultatGost = gostGolovi;
                    utakmica.Odigrana = true;
                }
            }
            else
            {
                if (utakmica.Kolo <= _kolo && utakmica.PostojiDogadaj() &&
                    (utakmica.Domacin.Oznaka == _oznakaKluba || utakmica.Gost.Oznaka == _oznakaKluba))
                {
                    utakmica.RezultatDomacin = domacinGolovi;
                    utakmica.RezultatGost = gostGolovi;
                    utakmica.Odigrana = true;
                }
            }
            gostGolovi = 0;
            domacinGolovi = 0;
        }

        public void Visit(SastavUtakmice sastav)
        {
        }

        public void Visit(Dogadaj dogadaj)
        {
            ObradiDogadajZaPogodak(dogadaj);
        }
    }
}
