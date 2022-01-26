using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    public class GetTablicaKartona : IVisit
    {
        private readonly int Kolo;
        private readonly CrveniKartonHandler Handler = new CrveniKartonHandler();
        private readonly ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private readonly ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();

        public GetTablicaKartona(int kolo = 0)
        {
            Kolo = kolo;
            Handler.SetNextHandler(ZutKartonHandler).SetNextHandler(ZamjenaHandler);
        }

        public void Visit(Dogadaj dogadaj)
        {
            if (Kolo == 0)
            {
                Handler.ProccessEvent(dogadaj);
            }
            else
            {
                if(dogadaj.Utakmica.Kolo <= Kolo)
                    Handler.ProccessEvent(dogadaj);
            }
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

        public void Visit(SastavUtakmice sastav)
        {
            sastav.Igrac.OnPostava(sastav.Vrsta);
        }

        public void Visit(Igrac igrac)
        {
        }

        public void Visit(Klub klub)
        {
        }

        public void Visit(Trener trener)
        {
        }
    }
}