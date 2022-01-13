using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;
using tgodek_zadaca_3.StatePattern;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaStrijelci : Statistika<int>
    {
        private int _kolo;
        private GolHandler GolHandler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler Handler = new ZutiKartonHandler();

        public GetTablicaStrijelci(int kolo = 0)
        {
            Rezultat = 0;
            _kolo = kolo;
            Handler.SetNextHandler(ZamjenaHandler).SetNextHandler(GolHandler);
        }

        public override void Visit(Dogadaj dogadaj)
        {

            //TODO: Dodati statistiku za ukupni broj pogodka
            
            if (_kolo != 0 && dogadaj.Utakmica.Kolo <= _kolo)
            {
                Handler.ProccessEvent(dogadaj);
            }
            else
            {
                Handler.ProccessEvent(dogadaj);
            }
        }

        public override void Visit(SastavUtakmice sastav)
        {
            if (sastav.Vrsta == "S")
                sastav.Igrac.SetState(new Igra());
            else if (sastav.Vrsta == "P")
                sastav.Igrac.SetState(new Pricuva());
        }

        public override void Visit(Utakmica utakmica)
        {
            foreach (var igrac in utakmica.Domacin.ListaIgraca())
            {
                igrac.SetState(new Idle());
            }
            foreach (var igrac in utakmica.Gost.ListaIgraca())
            {
                igrac.SetState(new Idle());
            }
        }

        public override void Visit(Trener trener) {}

        public override void Visit(Igrac igrac) {}

        public override void Visit(Klub klub) {}
    }
}
