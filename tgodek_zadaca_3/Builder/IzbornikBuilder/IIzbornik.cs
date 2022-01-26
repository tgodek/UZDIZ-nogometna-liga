using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3
{
    interface IIzbornik
    {
        public IIzbornik DodajZastavicu(string zastavica);
        public IIzbornik DodajKolo(int kolo);
        public IIzbornik DodajKlub(string klub);
        public IIzbornik DodajKlub2(string klub);
        public IIzbornik DodajBroj(int broj);
    }
}
