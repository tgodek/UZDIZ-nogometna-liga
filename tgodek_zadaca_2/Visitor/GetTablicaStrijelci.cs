using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_2.Composite;

namespace tgodek_zadaca_2.Visitor
{
    class GetTablicaStrijelci : Statistika<int>
    {
        private int _kolo;

        public GetTablicaStrijelci(int kolo = 0)
        {
            Rezultat = 0;
            _kolo = kolo;
        }

        public override void Visit(Dogadaj dogadaj)
        {
            if (_kolo == 0)
            {
                if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
                { 
                    dogadaj.Igrac.BrojPogodaka++;
                    Rezultat += 1;
                }
            }
            else
            {
                if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Utakmica.Kolo <= _kolo)
                {
                    dogadaj.Igrac.BrojPogodaka++;
                    Rezultat += 1;
                }
            }
        }

        public override void Visit(Igrac igrac)
        {
        }

        public override void Visit(Klub klub)
        {
        }

        public override void Visit(SastavUtakmice sastav)
        {
        }

        public override void Visit(Trener trener)
        {
        }

        public override void Visit(Utakmica utakmica)
        {
        }
    }
}
