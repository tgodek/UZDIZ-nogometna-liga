using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3
{
    class IzbornikDirektor
    {
        private IIzbornik _builder;

        public IIzbornik Builder
        {
            set { _builder = value; }
        }

        public void IzradiIzbornik(string[] vrijednosti) 
        {
            if (vrijednosti.Length == 3 && vrijednosti[0] == "R" && int.TryParse(vrijednosti[2], out int kolo) && 
                !Int32.TryParse(vrijednosti[1], out _))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajKlub(vrijednosti[1])
                    .DodajKolo(kolo);
            }
            else if (vrijednosti.Length == 2 &&
                (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K" || vrijednosti[0] == "IK") &&
                int.TryParse(vrijednosti[1], out kolo))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajKolo(kolo);
            }
            else if (vrijednosti.Length == 2 && 
                (vrijednosti[0] == "R" || vrijednosti[0] == "IR") && !int.TryParse(vrijednosti[1], out _))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajKlub(vrijednosti[1]);
            }

            else if (vrijednosti.Length == 1 &&
                (vrijednosti[0] == "T" || vrijednosti[0] == "S" || vrijednosti[0] == "K" || vrijednosti[0] == "IG"))
            {
                _builder.DodajZastavicu(vrijednosti[0]);
            }

            else if (vrijednosti.Length == 5 &&
                vrijednosti[0] == "D" && int.TryParse(vrijednosti[1], out int sekunde) && int.TryParse(vrijednosti[1], out kolo))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajKolo(kolo)
                    .DodajKlub(vrijednosti[2])
                    .DodajKlub2(vrijednosti[3])
                    .DodajBroj(sekunde);
            }

            else if (vrijednosti.Length == 4 && vrijednosti[0] == "SU" && int.TryParse(vrijednosti[1], out kolo))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajKolo(kolo)
                    .DodajKlub(vrijednosti[2])
                    .DodajKlub2(vrijednosti[3]);
            }
            else if (vrijednosti.Length == 2 && (vrijednosti[0] == "GR" || vrijednosti[0] == "VR") && int.TryParse(vrijednosti[1], out int broj))
            {
                _builder
                    .DodajZastavicu(vrijednosti[0])
                    .DodajBroj(broj);
            }
        }
    }
}
