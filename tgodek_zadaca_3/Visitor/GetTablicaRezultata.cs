using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaRezultata : IOperation
    {
        private int _kolo;
        private string _oznakaKluba { get; set; }
        private GolHandler Handler = new GolHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private AutogolHandler AutogolHandler = new AutogolHandler();

        public GetTablicaRezultata(string oznakaKluba, int kolo = 0)
        {
            _kolo = kolo;
            _oznakaKluba = oznakaKluba;
            Handler.SetNextHandler(ZamjenaHandler).SetNextHandler(ZutKartonHandler).SetNextHandler(CrveniKartonHandler).SetNextHandler(AutogolHandler);
        }
         
        public void Visit(Utakmica utakmica)
        {
            if (_kolo == 0)
            {
                if (utakmica.PostojiDogadaj() && (utakmica.Domacin.Oznaka == _oznakaKluba || utakmica.Gost.Oznaka == _oznakaKluba))
                {
                    utakmica.Odigrana = true;
                }
            }
            else
            {
                if (utakmica.Kolo <= _kolo && utakmica.PostojiDogadaj() &&
                    (utakmica.Domacin.Oznaka == _oznakaKluba || utakmica.Gost.Oznaka == _oznakaKluba))
                {
                    utakmica.Odigrana = true;
                }
            }
            
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

        public void Visit(Dogadaj dogadaj)
        {
            Handler.ProccessEvent(dogadaj);
        }

        public void Visit(SastavUtakmice sastav)
        {
            sastav.Igrac.OnPostava(sastav.Vrsta);
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
       

    }
}
