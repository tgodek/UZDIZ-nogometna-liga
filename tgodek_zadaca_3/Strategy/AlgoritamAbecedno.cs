using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Strategy
{
    public class AlgoritamAbecedno : IStrategy
    {
        private List<Klub> domacini = new List<Klub>();
        private List<Klub> gosti = new List<Klub>();

        public (List<Klub>, List<Klub>) Generiraj()
        {
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var klubovi = prvenstvo.Liga.FindAll(e => e.GetType() == typeof(Klub));
            var sortiraniKlubovi = klubovi.Select(k => k as Klub).OrderBy(k => k.Naziv).ToList();
            var brojKlubova = sortiraniKlubovi.Count;

            if (brojKlubova % 2 == 0)
            {
                for (int i = 0; i < brojKlubova; i++)
                {
                    if (i >= brojKlubova / 2)
                    {
                        gosti.Add(sortiraniKlubovi[i]);
                    }
                    else
                    {
                        domacini.Add(sortiraniKlubovi[i]);
                    }
                }
            }
            else
            {
                double max = brojKlubova;
                double polovica = Math.Round(max / 2);
                for (int i = 0; i < brojKlubova; i++)
                {
                    if (i < polovica - 1)
                    {
                        domacini.Add(sortiraniKlubovi[i]);
                    }
                    else
                    {
                        gosti.Add(sortiraniKlubovi[i]);
                    }
                }
            }
            return (domacini, gosti);
        }
    }
}
