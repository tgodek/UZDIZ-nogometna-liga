using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    public class GetTablicaKartona : Statistika<SumaKartona>
    {
        private int _kolo;
        private SumaKartona suma;
        private CrveniKartonHandler Handler = new CrveniKartonHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();

        public GetTablicaKartona(int kolo = 0)
        {
            suma = new SumaKartona();
            Rezultat = suma;
            _kolo = kolo;
            Handler.SetNextHandler(ZutKartonHandler).SetNextHandler(ZamjenaHandler);

        }

        public override void Visit(Dogadaj dogadaj)
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

        public override void Visit(Igrac igrac)
        {
        }

        public override void Visit(Klub klub)
        {
        }

        public override void Visit(SastavUtakmice sastav)
        {
            sastav.Igrac.OnPostava(sastav.Vrsta);
        }

        public override void Visit(Trener trener)
        {
        }
    }
}