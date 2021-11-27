using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Visitor
{
    public class GetTablicaKartona : Get<TablicaKartona>
    {
        private string _oznakaKlub;
        private int _kolo;

        public GetTablicaKartona(string oznakaKluba, int kolo = 0)
        {
            _oznakaKlub = oznakaKluba;
            _kolo = kolo;
        }

        public override void Visit(Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 10)
            {
                if (dogadaj.Igrac.ZutiKarton == 1)
                {
                    dogadaj.Igrac.DrugiZutiKarton++;
                    dogadaj.Klub.DrugiZutiKarton++;
                }
                if (dogadaj.Igrac.ZutiKarton == 0)
                { 
                    dogadaj.Igrac.ZutiKarton++;
                    dogadaj.Klub.ZutiKarton++;
                }
                
                Console.WriteLine("{0} {1} {2}", dogadaj.Igrac.Ime, dogadaj.Igrac.ZutiKarton, dogadaj.Igrac.DrugiZutiKarton); 
            }
        }

        public override void Visit(Igrac igrac)
        {
        }

        public override void Visit(Klub klub)
        {
            klub.DetaljiKomponente();
        }

        public override void Visit(SastavUtakmice sastav)
        {
        }

        public override void Visit(Trener trener)
        {
        }

        public override void Visit(Utakmica utakmica)
        {
            //utakmica.Gost.DetaljiKomponente();
            utakmica.Domacin.ResetIgrace();
            utakmica.Gost.ResetIgrace();
        }   
    }
}