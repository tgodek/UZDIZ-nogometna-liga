using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaPrvenstva : IVisit
    {
        private readonly int Kolo;
        private GolHandler Handler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private AutogolHandler AutogolHandler = new AutogolHandler();

        public GetTablicaPrvenstva(int kolo = 0)
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

        private void ObradiUtakmicu(Utakmica utakmica)
        {
            if (utakmica.Gost.BrojOdigranihKola != utakmica.Kolo && utakmica.PostojiDogadaj())
                utakmica.Gost.BrojOdigranihKola += 1;
            if (utakmica.Domacin.BrojOdigranihKola != utakmica.Kolo && utakmica.PostojiDogadaj())
                utakmica.Domacin.BrojOdigranihKola += 1;

            if (utakmica.RezultatDomacin > utakmica.RezultatGost)
            {
                utakmica.Domacin.BrojBodova += 3;
                utakmica.Domacin.BrojPobjeda += 1;
                utakmica.Gost.BrojPoraza += 1;
            }
            if (utakmica.RezultatGost > utakmica.RezultatDomacin)
            {
                utakmica.Gost.BrojBodova += 3;
                utakmica.Gost.BrojPobjeda += 1;
                utakmica.Domacin.BrojPoraza += 1;
            }
            if (utakmica.RezultatDomacin == utakmica.RezultatGost)
            {
                utakmica.Domacin.BrojBodova += 1;
                utakmica.Gost.BrojBodova += 1;
                utakmica.Gost.BrojNerješenih += 1;
                utakmica.Domacin.BrojNerješenih += 1;
            }
        }

        public void Visit(Utakmica utakmica)
        {
            if (Kolo == 0 && utakmica.PostojiDogadaj()) 
            {
                ObradiUtakmicu(utakmica);
            }
            else
            {
                if (utakmica.Kolo <= Kolo && utakmica.PostojiDogadaj())
                    ObradiUtakmicu(utakmica);
            }

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
