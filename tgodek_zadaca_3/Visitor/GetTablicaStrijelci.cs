using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaStrijelci : IOperation
    {
        private int _kolo;
        private GolHandler Handler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private AutogolHandler AutogolHandler = new AutogolHandler();

        public GetTablicaStrijelci(int kolo = 0)
        {
            _kolo = kolo;
            Handler.SetNextHandler(ZamjenaHandler).SetNextHandler(ZutKartonHandler).SetNextHandler(CrveniKartonHandler).SetNextHandler(AutogolHandler);
        }

        public void Visit(Dogadaj dogadaj)
        {
            if (_kolo != 0 && dogadaj.Utakmica.Kolo <= _kolo)
            {
                Handler.ProccessEvent(dogadaj);
            }
            else
            {
                Handler.ProccessEvent(dogadaj);
            }
        }

        public void Visit(SastavUtakmice sastav)
        {
            sastav.Igrac.OnPostava(sastav.Vrsta);
        }

        public void Visit(Utakmica utakmica)
        {
            foreach (var igrac in utakmica.Domacin.ListaIgraca())
            {
                igrac.ResetirajKartone();
                igrac.ResetState();
            }
            foreach (var igrac in utakmica.Gost.ListaIgraca())
            {
                igrac.ResetirajKartone();
                igrac.ResetState();
            }
        }

        public void Visit(Trener trener) {}

        public void Visit(Igrac igrac) {}

        public void Visit(Klub klub) {}
    }
}
