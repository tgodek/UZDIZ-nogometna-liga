using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Visitor
{
    class GetTablicaStrijelci : Get<SumaPogodaka>
    {
        private int _kolo;
        private SumaPogodaka suma;

        public GetTablicaStrijelci(int kolo = 0)
        {
            suma = new SumaPogodaka();
            Result = suma;
            _kolo = kolo;
        }

        public override void Visit(Dogadaj dogadaj)
        {
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
