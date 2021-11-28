using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Visitor
{
    class GetLjestvicaPrvenstva : Get<SumaLjestvicePrvenstva>
    {
        private int _kolo;
        private int domacinGolovi { get; set; }
        private int gostGolovi { get; set; }

        private SumaLjestvicePrvenstva suma;
        public GetLjestvicaPrvenstva(int kolo = 0)
        {
            suma = new SumaLjestvicePrvenstva();
            Result = suma;
            domacinGolovi = 0;
            gostGolovi = 0;
            _kolo = kolo;
        }

        public override void Visit(Dogadaj dogadaj)
        {

            if (_kolo == 0)
            {
                if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                {
                    dogadaj.Klub.BrojDanihGolova += 1;
                    domacinGolovi += 1;
                    dogadaj.Utakmica.Gost.BrojPrimljenihGolova += 1;
                    suma.SumaBrojaDanihGolova += 1;
                    suma.SumaBrojaPrimljenihGolova += 1;
                }
                if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                {
                    dogadaj.Klub.BrojDanihGolova += 1;
                    gostGolovi += 1;
                    dogadaj.Utakmica.Domacin.BrojPrimljenihGolova += 1;
                    suma.SumaBrojaDanihGolova += 1;
                    suma.SumaBrojaPrimljenihGolova += 1;
                }
            }
            else
            {
                if (dogadaj.Utakmica.Kolo <= _kolo)
                {
                    if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Klub.Oznaka == dogadaj.Utakmica.Domacin.Oznaka)
                    {
                        dogadaj.Klub.BrojDanihGolova += 1;
                        domacinGolovi += 1;
                        dogadaj.Utakmica.Gost.BrojPrimljenihGolova += 1;
                        suma.SumaBrojaDanihGolova += 1;
                        suma.SumaBrojaPrimljenihGolova += 1;
                    }
                    if ((dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2) && dogadaj.Klub.Oznaka == dogadaj.Utakmica.Gost.Oznaka)
                    {
                        dogadaj.Klub.BrojDanihGolova += 1;
                        gostGolovi += 1;
                        dogadaj.Utakmica.Domacin.BrojPrimljenihGolova += 1;
                        suma.SumaBrojaDanihGolova += 1;
                        suma.SumaBrojaPrimljenihGolova += 1;
                    }
                }
            
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
        }

        public override void Visit(Trener trener)
        {
        }

        public override void Visit(Utakmica utakmica)
        {
            if (_kolo == 0 && utakmica.PostojiDogadaj())
            {
                if (utakmica.Gost.BrojOdigranihKola != utakmica.Kolo)
                    utakmica.Gost.BrojOdigranihKola += 1;
                if (utakmica.Domacin.BrojOdigranihKola != utakmica.Kolo)
                    utakmica.Domacin.BrojOdigranihKola += 1;

                if (domacinGolovi > gostGolovi)
                {
                    utakmica.Domacin.BrojBodova += 3;
                    utakmica.Domacin.BrojPobjeda += 1;
                    utakmica.Gost.BrojPoraza += 1;
                    suma.SumaBrojaPobjeda += 1;
                    suma.SumaBrojaPoraza += 1;
                    suma.SumaBrojaBodova += 3;
                }
                if (gostGolovi > domacinGolovi)
                {
                    utakmica.Gost.BrojBodova += 3;
                    utakmica.Gost.BrojPobjeda += 1;
                    utakmica.Domacin.BrojPoraza += 1;
                    suma.SumaBrojaPobjeda += 1;
                    suma.SumaBrojaPoraza += 1;
                    suma.SumaBrojaBodova += 3;
                }
                if (domacinGolovi == gostGolovi)
                {
                    utakmica.Domacin.BrojBodova += 1;
                    utakmica.Gost.BrojBodova += 1;
                    utakmica.Gost.BrojNerješenih += 1;
                    utakmica.Domacin.BrojNerješenih += 1;
                    suma.SumaBrojaNerjesenih += 2;
                    suma.SumaBrojaBodova += 2;
                }
            }
            else
            {
                if (utakmica.Kolo <= _kolo && utakmica.PostojiDogadaj())
                {
                    if (utakmica.Gost.BrojOdigranihKola != utakmica.Kolo)
                        utakmica.Gost.BrojOdigranihKola += 1;
                    if (utakmica.Domacin.BrojOdigranihKola != utakmica.Kolo)
                        utakmica.Domacin.BrojOdigranihKola += 1;

                    if (domacinGolovi > gostGolovi)
                    {
                        utakmica.Domacin.BrojBodova += 3;
                        utakmica.Domacin.BrojPobjeda += 1;
                        utakmica.Gost.BrojPoraza += 1;
                        suma.SumaBrojaPobjeda += 1;
                        suma.SumaBrojaPoraza += 1;
                        suma.SumaBrojaBodova += 3;
                    }
                    if (gostGolovi > domacinGolovi)
                    {
                        utakmica.Gost.BrojBodova += 3;
                        utakmica.Gost.BrojPobjeda += 1;
                        utakmica.Domacin.BrojPoraza += 1;
                        suma.SumaBrojaPobjeda += 1;
                        suma.SumaBrojaPoraza += 1;
                        suma.SumaBrojaBodova += 3;
                    }
                    if (domacinGolovi == gostGolovi)
                    {
                        utakmica.Domacin.BrojBodova += 1;
                        utakmica.Gost.BrojBodova += 1;
                        utakmica.Gost.BrojNerješenih += 1;
                        utakmica.Domacin.BrojNerješenih += 1;
                        suma.SumaBrojaNerjesenih += 2;
                        suma.SumaBrojaBodova += 2;
                    }
                }
            }
            Console.WriteLine("gost: {0}", gostGolovi);
            Console.WriteLine("domacin: {0}", domacinGolovi);
            gostGolovi = 0;
            domacinGolovi = 0;
        }
    }
}
