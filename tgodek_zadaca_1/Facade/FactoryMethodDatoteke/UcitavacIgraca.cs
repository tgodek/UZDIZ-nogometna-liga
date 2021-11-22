using tgodek_zadaca_1.Model;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1.FactoryMethod.Datoteke
{
    internal class UcitavacIgraca : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            foreach (var item in list)
            {
                var value = item.Split(';');
                var noviIgrac = Igrac.ProvjeriIgraca(value[0], value[1], value[2], value[3]);
                if (noviIgrac != null)
                {
                    prvenstvo.DodajIgrac(noviIgrac);
                }
            }
        }
    }
}
