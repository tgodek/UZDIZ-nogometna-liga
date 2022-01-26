using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaStrijelci : IVisit
    {
        private int Kolo;
        private GolHandler Handler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private AutogolHandler AutogolHandler = new AutogolHandler();

        public GetTablicaStrijelci(int kolo = 0)
        {
            Kolo = kolo;
            Handler.SetNextHandler(ZamjenaHandler)
                   .SetNextHandler(ZutKartonHandler)
                   .SetNextHandler(CrveniKartonHandler)
                   .SetNextHandler(AutogolHandler);
        }

        public void Visit(Dogadaj dogadaj)
        {
            if (Kolo == 0)
            {
                Handler.ProccessEvent(dogadaj);
            }
            else 
            {
                if (dogadaj.Utakmica.Kolo <= Kolo)
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
                igrac.ResetirajState();
            }
            foreach (var igrac in utakmica.Gost.ListaIgraca())
            {
                igrac.ResetirajKartone();
                igrac.ResetirajState();
            }
        }

        public void Visit(Trener trener) {}

        public void Visit(Igrac igrac) {}

        public void Visit(Klub klub) {}
    }
}
