using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Strategy
{
    class AlgoritamKlubTrener : IStrategy
    {
        private readonly List<Klub> domacini = new List<Klub>();
        private readonly List<Klub> gosti = new List<Klub>();

        public (List<Klub>, List<Klub>) GenerirajPolovice()
        {
            var prventsvo = Prvenstvo.DohvatiPrvenstvo();
            var klubovi = prventsvo.Liga.FindAll(e => e.GetType() == typeof(Klub));
            var sortiraniKlubovi = klubovi.Select(k => k as Klub)
                                          .OrderBy(k => k.Naziv.Length)
                                          .ThenByDescending(k => GetBrojSamoglasnika(k.Trener.Ime))
                                          .ToList();
            
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

        private int GetBrojSamoglasnika(string imeTrenera)
        {
            var brojSamoglasnika = 0;
            var ulaz = imeTrenera.ToLower();
            for (int i = 0; i < ulaz.Length; i++)
            {
                if (ulaz[i] == 'a' || ulaz[i] == 'e' || ulaz[i] == 'i' || ulaz[i] == 'o' || ulaz[i] == 'u')
                {
                    brojSamoglasnika++;
                }
            }
            return brojSamoglasnika;
        }
    }
}
