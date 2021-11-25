using System;
using tgodek_zadaca_1;
using tgodek_zadaca_1.Builder;
using tgodek_zadaca_1.Composite;

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
                ObradaDogadaja(value[0], value[1], value[2], value[3], value[4], value[5], prvenstvo, builder);
            }
        }

        private void ObradaDogadaja(string broj,string min,string _vrsta, string klub, string igrac, string zamjena, 
            Prvenstvo prvenstvo, KonkretniDogadaj builder)
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
                    builder.DodajOsnovno(utakmica, min, vrsta);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                {
                    Console.WriteLine("DOGADAJ | Preskacem dogadaj | Razlog: {0} | {1} {2} {3}",
                      sastavDogadajaError, broj, min, vrsta);
                }
            }
            if (vrsta == 1 || vrsta == 2 || vrsta == 3 || vrsta == 10 || vrsta == 11)
            {
                var _klub = utakmica.PronadiZapis(klub) as Klub;
                var _igrac =_klub.PronadiZapis(igrac) as Igrac;

                if (_klub == null)
                    sastavDogadajaError += "-- Dogadaj nema klub";
                if (_igrac == null)
                    sastavDogadajaError += "-- Dogadaj nema igraca";
                if (sastavDogadajaError == "")
                {
                    builder.DodajOsnovno(utakmica, min, vrsta);
                    builder.DodajKlubIIgraca(_klub, _igrac);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("DOGADAJ | Preskacem dogadaj | Razlog: {0} | {1} {2} {3} {4}",
                        sastavDogadajaError, broj, min, vrsta, igrac);

            }
            if (vrsta == 20)
            {
                var _klub = utakmica.PronadiZapis(klub) as Klub;
                var _igrac = _klub.PronadiZapis(igrac) as Igrac;
                var _zamjena = _klub.PronadiZapis(zamjena) as Igrac;
                if (_klub == null)
                    sastavDogadajaError += "-- Dogadaj nema klub";
                if (_igrac == null)
                    sastavDogadajaError += "-- Dogadaj nema igraca";
                if (_zamjena == null)
                    sastavDogadajaError += "-- Dogadaj nema zamjenu";

                if(sastavDogadajaError == "")
                {
                    builder.DodajOsnovno(utakmica, min, vrsta);
                    builder.DodajKlubIIgraca(_klub, _igrac);
                    builder.DodajZamjenu(_zamjena);
                    utakmica.DodajKomponentu(builder.Build());
                }
                else
                    Console.WriteLine("DOGADAJ | Preskacem dogadaj | Razlog: {0} | {1} {2} {3} {4} {5}",
                        sastavDogadajaError, broj, min, vrsta, igrac, zamjena);
            }
        }
    }
}
