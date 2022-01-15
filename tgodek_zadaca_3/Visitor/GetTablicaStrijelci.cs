using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaStrijelci : Statistika<int>
    {
        private int _kolo;
        private GolHandler Handler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();

        public GetTablicaStrijelci(int kolo = 0)
        {
            Rezultat = 0;
            _kolo = kolo;
            Handler.SetNextHandler(ZamjenaHandler).SetNextHandler(ZutKartonHandler).SetNextHandler(CrveniKartonHandler);
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
            sastav.Igrac.OnPostava(sastav.Vrsta);
        }

        public override void Visit(Utakmica utakmica)
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

        public override void Visit(Trener trener) {}

        public override void Visit(Igrac igrac) {}

        public override void Visit(Klub klub) {}
    }
}
