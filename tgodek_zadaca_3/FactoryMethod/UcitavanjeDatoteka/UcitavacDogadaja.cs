using System;
using tgodek_zadaca_3;
using tgodek_zadaca_3.Builder.DogadajBuilder;
using tgodek_zadaca_3.Composite;

namespace ucitavanje_datoteka
{
    internal class UcitavacDogadaja : IUcitavac
    {
        public void UcitajPodatke(string imeDatoteke)
        {
            var listaDogadaja = DatotekaUtil.UcitajDatoteku(imeDatoteke);

            for (var i = 0; i < listaDogadaja.Count; i++)
            {
                var value = listaDogadaja[i].Split(";");
                ObradaDogadaja(value[0], value[1], value[2], value[3], value[4], value[5], i);
            }
        }

        private void ObradaDogadaja(string broj,string min,string _vrsta, string klub, string igrac, string zamjena, int index)
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var builder = new KonkretniDogadaj();
            var direktor = new DogadajDirector { Builder = builder };

            var dogadajaError = "";
            var utakmica = prvenstvo.PronadiZapis(broj) as Utakmica;

            if (utakmica == null)
                dogadajaError += "-- Dogadaj nema utakmicu ";

            if (string.IsNullOrEmpty(min))
                dogadajaError += "-- Dogadaj nema minute ";

            if (!int.TryParse(_vrsta, out int vrsta))
                dogadajaError += "-- Dogadaj nema vrstu ";

            if (vrsta == 0 || vrsta == 99)
            {
                if (dogadajaError == "")
                {
                    direktor.IzradiOsnovniDogadaj(utakmica, min, vrsta);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                {
                    Console.WriteLine("ZAPIS {0} | DOGAĐAJ | Preskaćem događaj | Razlog: {1} | {2} {3} {4}",
                      index+1, dogadajaError, broj, min, vrsta);
                }
            }
            if (vrsta == 1 || vrsta == 2 || vrsta == 3 || vrsta == 10 || vrsta == 11)
            {
                SastavUtakmice _klubUSastavu = utakmica.PronadiZapis(klub) as SastavUtakmice;
                Igrac _igrac = null;
                if (_klubUSastavu != null)
                    _igrac = _klubUSastavu.Klub.IgracPostoji(igrac); 

                if (_klubUSastavu == null)
                    dogadajaError += "-- Klub nije u sastavu";
                if (_igrac == null)
                    dogadajaError += "-- Igrac nije u sastavu";
                if (dogadajaError == "")
                {
                    direktor.IzradiDogadajZaIgraca(utakmica, min, vrsta, _klubUSastavu.Klub, _igrac);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("ZAPIS {0} | DOGAĐAJ | Preskaćem događaj | Razlog: {1} | {2} {3} {4} {5} {6}",
                        index+1, dogadajaError, broj, min, vrsta, klub, igrac);
            }
            if (vrsta == 20)
            {
                SastavUtakmice postojeciKlub = utakmica.PronadiZapis(klub) as SastavUtakmice;
                Igrac postojeciIgrac = null;
                Igrac postojecaZamjena = null;
                
                if (postojeciKlub != null)
                {
                    postojeciIgrac = postojeciKlub.Klub.IgracPostoji(igrac);
                    postojecaZamjena = postojeciKlub.Klub.IgracPostoji(zamjena);
                }
                  
                if (postojeciKlub == null)
                    dogadajaError += "-- Klub nije u sastavu";
                if (postojeciIgrac == null)
                    dogadajaError += "-- Igrac nije u sastavu";
                if (postojecaZamjena == null)
                    dogadajaError += "-- Zamjena nije u sastavu";

                if(dogadajaError == "")
                {
                    direktor.IzradiDogadajZaZamjenu(utakmica, min, vrsta, postojeciKlub.Klub, postojeciIgrac, postojecaZamjena);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("ZAPIS {0} | DOGAĐAJ | Preskaćem događaj | Razlog: {1} | {2} {3} {4} {5} {6} {7}",
                        index+1, dogadajaError, broj, min, vrsta, klub, igrac, zamjena);
            }
        }
    }
}
