using System;
using tgodek_zadaca_1;
using tgodek_zadaca_1.Builder;

namespace ucitavanje_datoteka
{
    internal class UcitavacDogadaja : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var builder = new KonkretniDogadaj();
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            foreach (var item in list)
            {
                var value = item.Split(';');

                Int32 utakmica;
                if (!Int32.TryParse(value[0], out utakmica))
                {
                    Console.WriteLine("DOGADAJ | Preskacem dogadaj | Razlog: -- Dogadaj nema utakmicu");
                }

                if (String.IsNullOrEmpty(value[1]))
                {
                    Console.WriteLine("DOGADAJ | Preskacem dogadaj | Razlog: -- Dogadaj nema minute");
                }

                int vrsta;
                if (!Int32.TryParse(value[2], out vrsta))
                {
                    Console.WriteLine("DOGADAJ | -- Dogadaj nema vrstu");
                }

                else
                {
                    if (vrsta == 0 || vrsta == 99)
                    {
                        builder.DodajOsnovno(utakmica, value[1], vrsta);
                        prvenstvo.DodajDogadaj(builder.DohvatiDohadaj());
                    }
                    if (vrsta == 1 || vrsta == 2 || vrsta == 3 || vrsta == 10 || vrsta == 11)
                    {
                        builder.DodajOsnovno(utakmica, value[1], vrsta);
                        builder.DodajIgracaIKlub(value[3], value[4]);
                        prvenstvo.DodajDogadaj(builder.DohvatiDohadaj());
                    }
                    if (vrsta == 20)
                    {
                        builder.DodajOsnovno(utakmica, value[1], vrsta);
                        builder.DodajIgracaIKlub(value[3], value[4]);
                        builder.DodajZamjenu(value[5]);
                        prvenstvo.DodajDogadaj(builder.DohvatiDohadaj());
                    }
                }
            }
        }
    }
}
