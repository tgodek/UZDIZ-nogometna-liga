using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Model;

namespace tgodek_zadaca_1.Builder
{
    interface IDogadaj
    {
        public void DodajOsnovno(int utakmica, string minute, int vrsta);
        public void DodajIgracaIKlub(string klub, string igrac);
        public void DodajZamjenu(string zamjena);
    }
}
