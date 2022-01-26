using System;
using System.Collections.Generic;
using System.Linq;
using tgodek_zadaca_3.Composite;
using tgodek_zadaca_3.Memento;

namespace tgodek_zadaca_3.Strategy
{
    class RasporedContext
    {
        private List<Klub> domacini = new List<Klub>();
        private List<Klub> gosti = new List<Klub>();
        private List<Utakmica> utakmice = new List<Utakmica>();

        private IStrategy _strategy;
        public RasporedContext() { }

        public void PostaviStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void PohraniRaspored()
        {
            (domacini, gosti) = this._strategy.Generiraj();
            GenerirajRaspored();
            Save();
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

        private void DodajNoveUtakmice(List<(Klub, Klub)> parovi)
        {
            var brojUtakmica = utakmice.Count;
            var brojZadnjeUtakmice = 0;
            var sadasnjeKolo = 1;
            if (brojUtakmica != 0)
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

        public void Save()
        {
            var caretaker = Caretaker.DohvatiCaretaker();
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            prvenstvo.AktivniRaspored.Broj = caretaker.ZadnjiRaspored() + 1;
            prvenstvo.AktivniRaspored.Datum = DateTime.Parse(DateTime.Now.ToString("G"));
            prvenstvo.AktivniRaspored.Utakmice = utakmice;
            caretaker.Backup(prvenstvo.AktivniRaspored.SaveMemento());
        }
    }
}
