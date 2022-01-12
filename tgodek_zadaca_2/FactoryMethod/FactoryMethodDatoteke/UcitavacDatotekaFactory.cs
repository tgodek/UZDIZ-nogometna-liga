namespace ucitavanje_datoteka
{
    class UcitavacDatotekaFactory
    {
        public IUcitavac DohvatiPodatke(string key)
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
