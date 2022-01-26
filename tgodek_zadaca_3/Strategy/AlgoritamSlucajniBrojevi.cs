using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Strategy
{
    public class AlgoritamSlucajniBrojevi : IStrategy
    {
        private List<Klub> domacini = new List<Klub>();
        private List<Klub> gosti = new List<Klub>();

        public (List<Klub>, List<Klub>) Generiraj()
        {
            var prventsvo = Prvenstvo.DohvatiPrvenstvo();
            var klubovi = prventsvo.Liga.FindAll(e => e.GetType() == typeof(Klub));
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
            return (domacini, gosti);
        }
    }
}
