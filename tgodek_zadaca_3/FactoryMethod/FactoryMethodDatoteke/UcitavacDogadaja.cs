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
            var list = DatotekaUtil.ReadFile(imeDatoteke);
            var builder = new KonkretniDogadaj();
            var direktor = new DogadajDirector();
            direktor.Builder = builder;
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            for (var i = 0; i < list.Count; i++)
            {
                var value = list[i].Split(";");
                ObradaDogadaja(value[0], value[1], value[2], value[3], value[4], value[5], prvenstvo, builder, i, direktor);
            }
        }

        private void ObradaDogadaja(string broj,string min,string _vrsta, string klub, string igrac, string zamjena, 
            Prvenstvo prvenstvo, KonkretniDogadaj builder, int index, DogadajDirector director)
        {
            
            var sastavDogadajaError = "";
            var utakmica = prvenstvo.PronadiZapis(broj) as Utakmica;

            if (utakmica == null)
                sastavDogadajaError += "-- Dogadaj nema utakmicu ";

            if (String.IsNullOrEmpty(min))
                sastavDogadajaError += "-- Dogadaj nema minute ";

            Int32 vrsta;
            if (!Int32.TryParse(_vrsta, out vrsta))
                sastavDogadajaError += "-- Dogadaj nema vrstu ";
          
            if (vrsta == 0 || vrsta == 99)
            {
                if (sastavDogadajaError == "")
                {
                    director.IzradiOsnovniDogadaj(utakmica, min, vrsta);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                {
                    Console.WriteLine("ZAPIS {0} | DOGADAJ | Preskacem dogadaj | Razlog: {1} | {2} {3} {4}",
                      index+1, sastavDogadajaError, broj, min, vrsta);
                }
            }
            if (vrsta == 1 || vrsta == 2 || vrsta == 3 || vrsta == 10 || vrsta == 11)
            {
                SastavUtakmice _klubUSastavu = utakmica.PronadiZapis(klub) as SastavUtakmice;
                Igrac _igrac = null;
                if (_klubUSastavu != null)
                    _igrac = _klubUSastavu.Klub.IgracPostoji(igrac); 

                if (_klubUSastavu == null)
                    sastavDogadajaError += "-- Klub se ne nalazi u sastavu";
                if (_igrac == null)
                    sastavDogadajaError += "-- Igrac se ne nalazi u sastavu";
                if (sastavDogadajaError == "")
                {
                    director.IzradiDogadajZaIgraca(utakmica, min, vrsta, _klubUSastavu.Klub, _igrac);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("ZAPIS {0} | DOGADAJ | Preskacem dogadaj | Razlog: {1} | {2} {3} {4} {5} {6}",
                        index+1, sastavDogadajaError, broj, min, vrsta, klub, igrac);
            }
            if (vrsta == 20)
            {
                SastavUtakmice _klubUSastavu = utakmica.PronadiZapis(klub) as SastavUtakmice;
                Igrac _igrac = null;
                Igrac _zamjena = null;
                if (_klubUSastavu != null)
                {
                    _igrac = _klubUSastavu.Klub.IgracPostoji(igrac);
                    _zamjena = _klubUSastavu.Klub.IgracPostoji(zamjena);
                }
                  
                if (_klubUSastavu == null)
                    sastavDogadajaError += "-- Klub se ne nalazi u sastavu";
                if (_igrac == null)
                    sastavDogadajaError += "-- Igrac se ne nalazi u sastavu";
                if (_zamjena == null)
                    sastavDogadajaError += "-- Zamjena se ne nalazi u sastavu";

                if(sastavDogadajaError == "")
                {
                    director.IzradiDogadajZaZamjenu(utakmica, min, vrsta, _klubUSastavu.Klub, _igrac, _zamjena);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("ZAPIS {0} | DOGADAJ | Preskacem dogadaj | Razlog: {1} | {2} {3} {4} {5} {6} {7}",
                        index+1, sastavDogadajaError, broj, min, vrsta, klub, igrac, zamjena);
            }
        }
    }
}
