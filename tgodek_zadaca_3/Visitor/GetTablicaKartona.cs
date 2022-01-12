﻿using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Visitor
{
    public class GetTablicaKartona : Statistika<SumaKartona>
    {
        private int _kolo;
        private SumaKartona suma;

        public GetTablicaKartona(int kolo = 0)
        {
            suma = new SumaKartona();
            Rezultat = suma;
            _kolo = kolo;
        }

        private void ObradiKartone(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 10)
            {
                if (dogadaj.Igrac.ZutiKarton == 1)
                {
                    dogadaj.Igrac.DrugiZutiKarton++;
                    dogadaj.Klub.DrugiZutiKarton++;
                    suma.UkDrugihZutih += 1;
                }
                if (dogadaj.Igrac.ZutiKarton == 0)
                {
                    dogadaj.Igrac.ZutiKarton++;
                    dogadaj.Klub.ZutiKarton++;
                    suma.UkZutih += 1;
                }
            }
            if (dogadaj.Vrsta == 11)
            {
                if (dogadaj.Igrac.CrveniKarton == 0)
                {
                    dogadaj.Igrac.CrveniKarton++;
                    dogadaj.Klub.CrveniKarton++;
                    suma.UkCrvenih += 1;
                }
            }
        }

        public override void Visit(Dogadaj dogadaj)
        {
            if (_kolo == 0)
                ObradiKartone(dogadaj);
            else 
            {
                if (dogadaj.Utakmica.Kolo <= _kolo)
                    ObradiKartone(dogadaj);
            }
        }

        public override void Visit(Utakmica utakmica)
        {
            utakmica.Domacin.ResetIgrace();
            utakmica.Gost.ResetIgrace();
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
    }
}