using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaRezultata : IVisit
    {
        private readonly int Kolo;
        private string OznakaKluba { get; set; }
        private readonly GolHandler Handler = new GolHandler();
        private readonly ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private readonly ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private readonly CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private readonly AutogolHandler AutogolHandler = new AutogolHandler();

        public GetTablicaRezultata(string oznakaKluba, int kolo = 0)
        {
            Kolo = kolo;
            OznakaKluba = oznakaKluba;
            Handler.SetNextHandler(ZamjenaHandler)
                .SetNextHandler(ZutKartonHandler)
                .SetNextHandler(CrveniKartonHandler)
                .SetNextHandler(AutogolHandler);
        }
         
        public void Visit(Utakmica utakmica)
        {
            if (Kolo == 0)
            {
                if (utakmica.PostojiDogadaj() && (utakmica.Domacin.Oznaka == OznakaKluba || utakmica.Gost.Oznaka == OznakaKluba))
                {
                    utakmica.Odigrana = true;
                }
            }
            else
            {
                if (utakmica.Kolo <= Kolo && utakmica.PostojiDogadaj() &&
                    (utakmica.Domacin.Oznaka == OznakaKluba || utakmica.Gost.Oznaka == OznakaKluba))
                {
                    utakmica.Odigrana = true;
                }
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
