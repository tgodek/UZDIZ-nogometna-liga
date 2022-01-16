using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Raspored
{
    public class AlgoritamSlucajniBrojevi
    {
        private List<Klub> domacini = new List<Klub>();
        private List<Klub> gosti = new List<Klub>();
        private List<Utakmica> utakmice = new List<Utakmica>();

        public void Generiraj() 
        {
            GenerirajPolovice();
            GenerirajRaspored();
            IspisUtakmica();
        }

        private void GenerirajPolovice()
        {
            var liga = Prvenstvo.DohvatiPrvenstvo();
            var klubovi = liga.GetLiga().FindAll(e => e.GetType() == typeof(Klub));
            var brojKlubova = klubovi.Count;

            if (brojKlubova % 2 == 0)
            {
                var preostaliIndexiKlubova = Enumerable.Range(0, brojKlubova).ToList();
                var rand = new Random();
                var brojac = 0;

                for (; preostaliIndexiKlubova.Count != 0;)
                {
                    brojac++;
                    var trenutni = preostaliIndexiKlubova[rand.Next(0, preostaliIndexiKlubova.Count)];
                    if (brojac > brojKlubova / 2)
                    {
                        gosti.Add((Klub)klubovi[trenutni]);
                    }
                    else
                    {
                        domacini.Add((Klub)klubovi[trenutni]);
                    }
                    preostaliIndexiKlubova.Remove(trenutni);
                }
            }
            else
            {
                double max = brojKlubova;
                double polovica = Math.Round(max / 2);
                var preostaliIndexiKlubova = Enumerable.Range(0, brojKlubova).ToList();
                var rand = new Random();
                var brojac = 0;
                for (; preostaliIndexiKlubova.Count != 0;)
                {
                    brojac++;
                    var trenutni = preostaliIndexiKlubova[rand.Next(0, preostaliIndexiKlubova.Count)];
                    if (brojac > polovica)
                    {
                        domacini.Add((Klub)klubovi[trenutni]);
                    }
                    else
                    {
                        gosti.Add((Klub)klubovi[trenutni]);
                    }
                    preostaliIndexiKlubova.Remove(trenutni);
                }
            }
        }

        private void IspisUtakmica() 
        {
            foreach(var utakmica in utakmice)
            {
                Console.WriteLine(utakmica.Broj + " " + utakmica.Kolo + " " + utakmica.Domacin.Naziv + " " + utakmica.Gost.Naziv);
            }
        }

        private void DodajNoveUtakmice(List<(Klub,Klub)> parovi)
        {
            var ut = utakmice.Count;
            var brojZadnjeUtakmice = 0;
            var sadasnjeKolo = 1;
            if (ut != 0) 
            {
                var zadnjaUtakmica = utakmice.Last();
                brojZadnjeUtakmice = zadnjaUtakmica.Broj;
                sadasnjeKolo = zadnjaUtakmica.Kolo + 1;
            }

            foreach (var par in parovi)
            {
                brojZadnjeUtakmice++;
                var datum = DateTime.Parse(DateTime.Now.ToString("g"));
                var utakmica = new Utakmica(brojZadnjeUtakmice, sadasnjeKolo, par.Item1, par.Item2, datum);
                utakmice.Add(utakmica);
            }
        }

        private void GenerirajRaspored()
        {
            List<(Klub, Klub)> originaliParovi = new List<(Klub, Klub)>();
            List<(Klub, Klub)> tempOdabrani = new List<(Klub, Klub)>();
            List<(Klub, Klub)> tempReverse = new List<(Klub, Klub)>();

            var parovi =
                from k1 in domacini
                from k2 in gosti
                select new { domacin = k1, gost = k2 };

            foreach (var p in parovi)
            {
                var domacin = p.domacin;
                var gost = p.gost;
                originaliParovi.Add((domacin, gost));
            }

            while (originaliParovi.Count > 0)
            {
                var tempKlub = new List<Klub>();

                foreach (var domacin in domacini) 
                {
                    var pronadenPar = originaliParovi.FindLast(p => p.Item1 == domacin);
                    var gost = pronadenPar.Item2;
                    if (!tempKlub.Contains(gost) && (pronadenPar.Item1 != null && pronadenPar.Item2 != null))
                    {
                        tempKlub.Add(gost);
                        var reverseKlub = (pronadenPar.Item2, pronadenPar.Item1);
                        tempOdabrani.Add(pronadenPar);
                        tempReverse.Add(reverseKlub);
                    }
                    else
                    {
                        var noviPar = originaliParovi.Find(p => p.Item1 == domacin && !tempKlub.Contains(p.Item2));
                        if (noviPar.Item1 != null && noviPar.Item2 != null)
                        {
                            var reverseKlub = (noviPar.Item2, noviPar.Item1);
                            tempOdabrani.Add(noviPar);
                            tempReverse.Add(reverseKlub);
                            tempKlub.Add(noviPar.Item2);
                        }
                    }
                }

                DodajNoveUtakmice(tempOdabrani);
                DodajNoveUtakmice(tempReverse);

                var rezultat = originaliParovi.Except(tempOdabrani).ToList();
                originaliParovi = rezultat;
                tempOdabrani = new List<(Klub, Klub)>();
                tempReverse = new List<(Klub, Klub)>();
            }
        }
    }
}
