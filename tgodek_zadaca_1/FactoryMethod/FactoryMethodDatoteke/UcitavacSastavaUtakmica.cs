using tgodek_zadaca_1;
using tgodek_zadaca_1.Model;

namespace ucitavanje_datoteka
{
    internal class UcitavacSastavaUtakmica : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            foreach (var item in list)
            {
                var value = item.Split(';');
                var noviSastavUtakmice = SastavUtakmice.ProvjeriSastavUtakmice(value[0], value[1], value[2], value[3], value[4]);
                if (noviSastavUtakmice != null)
                {
                    prvenstvo.DodajSastavUtakmice(noviSastavUtakmice);
                }
            }
        }
    }
}
