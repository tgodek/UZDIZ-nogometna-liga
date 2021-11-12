using System;
using tgodek_zadaca_1.Builder;
using tgodek_zadaca_1.Model;
using tgodek_zadaca_1.Util;

namespace tgodek_zadaca_1
{
    interface ILoader
    {
        public void UcitajPodatke(string imeDatoteke);
    }

    public class UcitavacIgraca : ILoader
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = FileUtil.ReadFile(imeDatoteke);
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

    public class UcitavacKlubova : ILoader
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = FileUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            foreach (var item in list)
            {
                var value = item.Split(';');
                var noviKlub = Klub.ProvjeriKlub(value[0], value[1], value[2]);
                if (noviKlub != null)
                {
                    prvenstvo.DodajKlub(noviKlub);
                }
            }
        }
    }

    public class UcitavacUtakmica : ILoader
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = FileUtil.ReadFile(imeDatoteke);
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            foreach (var item in list)
            {
                var value = item.Split(';');
                var novaUtakmica = Utakmica.ProvjeriUtakmicu(value[0], value[1], value[2], value[3], value[4]);
                if (novaUtakmica != null)
                {
                    prvenstvo.DodajUtakmicu(novaUtakmica);
                } 
            }
        }
    }

    public class UcitavacSastavaUtakmica : ILoader
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = FileUtil.ReadFile(imeDatoteke);
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

    public class UcitavacDogadaja : ILoader
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var list = FileUtil.ReadFile(imeDatoteke);
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
                        builder.DodajIgracaIKlub(value[3],value[4]);
                        prvenstvo.DodajDogadaj(builder.DohvatiDohadaj());
                    }
                    if (vrsta== 20)
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
