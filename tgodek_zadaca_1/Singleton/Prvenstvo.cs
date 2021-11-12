using System;
using System.Collections.Generic;
using tgodek_zadaca_1.Model;

namespace tgodek_zadaca_1
{
    class Prvenstvo
    {
        private List<Igrac> igraci = new List<Igrac>();
        private List<Klub> klubovi = new List<Klub>();
        private List<Utakmica> utakmice = new List<Utakmica>();
        private List<SastavUtakmice> sastaviUtakmica = new List<SastavUtakmice>();
        private List<Dogadaj> dogadaji = new List<Dogadaj>();

        private static Prvenstvo instanca;

        public Prvenstvo()
        {
            
        }

        public static Prvenstvo DohvatiPrvenstvo()
        {
            if (instanca == null)
            {
                instanca = new Prvenstvo();
            }
            return instanca;
        }

        public void IspisLjestvice(Izbornik izbornik)
        {
            var ljestvica = new LjestvicaFactory().DohvatiLjestvicu(izbornik.Zastavica, izbornik.Kolo);
            ljestvica.Ispis();
            //Console.WriteLine("Zastavica: {0} Kolo: {1} Klub: {2}", izbornik.Zastavica, izbornik.Kolo, izbornik.Klub);
        }

        public List<Dogadaj> SviDogadaji()
        {
            return dogadaji;
        }

        public List<Igrac> SviIgraci()
        {
            return igraci;
        }
        public List<Utakmica> SveUtakmice()
        {
            return utakmice;
        }
        public List<Klub> SviKlubovi()
        {
            return klubovi;
        }

        public void DodajIgrac(Igrac igrac)
        {
            igraci.Add(igrac);
        }

        public void DodajKlub(Klub klub)
        {
            klubovi.Add(klub);
        }

        public void DodajUtakmicu(Utakmica utakmica)
        {
            utakmice.Add(utakmica);
        }

        public void DodajSastavUtakmice(SastavUtakmice sastavUtakmice)
        {
            sastaviUtakmica.Add(sastavUtakmice);
        }

        public void DodajDogadaj(Dogadaj dogadaj)
        {
            dogadaji.Add(dogadaj);
        }

        public void IspisiIgrace()
        {
            foreach (var igrac in igraci)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}",igrac.Klub, igrac.Ime, igrac.Pozicija, igrac.Datum);
            }
        }

        public void IspisiKlubove()
        {
            foreach (var klub in klubovi)
            {
                Console.WriteLine("{0}\t {1}\t {2}", klub.Oznaka, klub.Naziv, klub.Trener);
            }
        }

        public void IspisiUtakmice()
        {
            foreach (var utakmica in utakmice)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", utakmica.Broj, utakmica.Kolo, utakmica.Domacin, utakmica.Gost, utakmica.Pocetak);
            }
        }

        public void IspisiSastavUtakmica()
        {
            foreach (var sastav in sastaviUtakmica)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", sastav.Broj, sastav.Klub, sastav.Vrsta, sastav.Igrac, sastav.Pozicija);
            }
        }

        public void IspisiDogadaje()
        {
            foreach (var dogadaj in dogadaji)
            {
                Console.WriteLine("{0,4} {1,8}\t {2,8}\t {3,10}\t {4,20}\t {5}", dogadaj.Broj, dogadaj.Min, dogadaj.Vrsta, dogadaj.Klub, dogadaj.Igrac, dogadaj.Zamjena);
            }
        }
    }
}
