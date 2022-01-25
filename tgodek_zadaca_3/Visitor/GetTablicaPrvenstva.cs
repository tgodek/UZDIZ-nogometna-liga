using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;
using tgodek_zadaca_3.Util;

namespace tgodek_zadaca_3.Visitor
{
    class GetTablicaPrvenstva : Statistika<SumaLjestvicePrvenstva>
    {
        private readonly int _kolo;
        private int DomacinGolovi { get; set; }
        private int GostGolovi { get; set; }

        private SumaLjestvicePrvenstva suma;
        public GetTablicaPrvenstva(int kolo = 0)
        {
            suma = new SumaLjestvicePrvenstva();
            Rezultat = suma;
            DomacinGolovi = 0;
            GostGolovi = 0;
            _kolo = kolo;
        }

        private void OdrediGoloveZaKlubove(Klub klubZabioGol, Klub klubPrimioGol)
        {
            klubZabioGol.BrojDanihGolova += 1;
            klubPrimioGol.BrojPrimljenihGolova += 1;
            suma.SumaBrojaDanihGolova += 1;
            suma.SumaBrojaPrimljenihGolova += 1;
        }

        private void ObradiDogadajZaPogodak(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                {
                    OdrediGoloveZaKlubove(dogadaj.Klub, dogadaj.Utakmica.Gost);
                    DomacinGolovi += 1;
                }
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                {
                    OdrediGoloveZaKlubove(dogadaj.Klub, dogadaj.Utakmica.Domacin);
                    GostGolovi += 1;
                }
            }
            if(dogadaj.Vrsta == 3)
            {
                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                {
                    OdrediGoloveZaKlubove(dogadaj.Utakmica.Gost, dogadaj.Klub);
                    GostGolovi += 1;
                }

                if (dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                {
                    OdrediGoloveZaKlubove(dogadaj.Utakmica.Domacin, dogadaj.Klub);
                    DomacinGolovi += 1;
                }
            }
        }

        public override void Visit(Dogadaj dogadaj)
        {
            if (_kolo == 0)
                ObradiDogadajZaPogodak(dogadaj);

            else
            {
                if (dogadaj.Utakmica.Kolo <= _kolo)
                    ObradiDogadajZaPogodak(dogadaj);
            }
        }

        private void ObradiUtakmicu(Utakmica utakmica)
        {
            if (utakmica.Gost.BrojOdigranihKola != utakmica.Kolo)
                utakmica.Gost.BrojOdigranihKola += 1;
            if (utakmica.Domacin.BrojOdigranihKola != utakmica.Kolo)
                utakmica.Domacin.BrojOdigranihKola += 1;

            if (DomacinGolovi > GostGolovi)
            {
                utakmica.Domacin.BrojBodova += 3;
                utakmica.Domacin.BrojPobjeda += 1;
                utakmica.Gost.BrojPoraza += 1;
                suma.SumaBrojaPobjeda += 1;
                suma.SumaBrojaPoraza += 1;
                suma.SumaBrojaBodova += 3;
            }
            if (GostGolovi > DomacinGolovi)
            {
                utakmica.Gost.BrojBodova += 3;
                utakmica.Gost.BrojPobjeda += 1;
                utakmica.Domacin.BrojPoraza += 1;
                suma.SumaBrojaPobjeda += 1;
                suma.SumaBrojaPoraza += 1;
                suma.SumaBrojaBodova += 3;
            }
            if (DomacinGolovi == GostGolovi)
            {
                utakmica.Domacin.BrojBodova += 1;
                utakmica.Gost.BrojBodova += 1;
                utakmica.Gost.BrojNerješenih += 1;
                utakmica.Domacin.BrojNerješenih += 1;
                suma.SumaBrojaNerjesenih += 2;
                suma.SumaBrojaBodova += 2;
            }
        }

        public override void Visit(Utakmica utakmica)
        {
            if (_kolo == 0 && utakmica.PostojiDogadaj())
                ObradiUtakmicu(utakmica);
            else
            {
                if (utakmica.Kolo <= _kolo && utakmica.PostojiDogadaj())
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
            GostGolovi = 0;
            DomacinGolovi = 0;
        }

        public override void Visit(SastavUtakmice sastav)
        {
            sastav.Igrac.OnPostava(sastav.Vrsta);
        }

        public override void Visit(Igrac igrac)
        {
        }

        public override void Visit(Klub klub)
        {
        }

        public override void Visit(Trener trener)
        {
        }
    }
}
