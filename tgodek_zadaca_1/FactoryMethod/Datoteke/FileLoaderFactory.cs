using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1
{
    class FileLoaderFactory
    {
        public ILoader DohvatiPodatke(string key) 
        {
            if (key == "i")
                return new UcitavacIgraca();
            if (key == "k")
                return new UcitavacKlubova();
            if (key == "u")
                return new UcitavacUtakmica();
            if (key == "s")
                return new UcitavacSastavaUtakmica();
            if (key == "d")
                return new UcitavacDogadaja();
            return null;
        }
    }
}
