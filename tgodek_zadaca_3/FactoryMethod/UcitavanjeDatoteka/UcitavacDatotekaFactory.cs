namespace ucitavanje_datoteka
{
    internal class UcitavacDatotekaFactory
    {
        internal IUcitavac DohvatiPodatke(string key)
        {
            return key switch
            {
                "i" => new UcitavacIgraca(),
                "k" => new UcitavacKlubova(),
                "u" => new UcitavacUtakmica(),
                "s" => new UcitavacSastavaUtakmica(),
                "d" => new UcitavacDogadaja(),
                _ => null,
            };
        }
    }
}
