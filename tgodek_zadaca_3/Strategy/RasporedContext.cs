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
        private readonly List<Utakmica> utakmice = new List<Utakmica>();

        private IStrategy strategy;
        public RasporedContext() { }

        public void PostaviStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void BackupRaspored()
        {
            (domacini, gosti) = this.strategy.GenerirajPolovice();
            GenerirajRaspored();
            SaveRaspored();
        }

        private void GenerirajRaspored()
        {
            List<(Klub, Klub)> sviParovi = new List<(Klub, Klub)>();
            List<(Klub, Klub)> tempOdabrani = new List<(Klub, Klub)>();
            List<(Klub, Klub)> tempOdabraniReverse = new List<(Klub, Klub)>();

            var parovi =
                from k1 in domacini
                from k2 in gosti
                select new { domacin = k1, gost = k2 };

            foreach (var p in parovi)
            {
                sviParovi.Add((p.domacin, p.gost));
            }

            while (sviParovi.Count > 0)
            {
                var tempKlub = new List<Klub>();

                foreach (var domacin in domacini)
                {
                    var pronadenPar = sviParovi.FindLast(p => p.Item1 == domacin);
                    var gost = pronadenPar.Item2;
                    if (!tempKlub.Contains(gost) && (pronadenPar.Item1 != null && pronadenPar.Item2 != null))
                    {
                        tempKlub.Add(gost);
                        var reverseKlub = (pronadenPar.Item2, pronadenPar.Item1);
                        tempOdabrani.Add(pronadenPar);
                        tempOdabraniReverse.Add(reverseKlub);
                    }
                    else
                    {
                        var noviPar = sviParovi.Find(p => p.Item1 == domacin && !tempKlub.Contains(p.Item2));
                        if (noviPar.Item1 != null && noviPar.Item2 != null)
                        {
                            var reverseKlub = (noviPar.Item2, noviPar.Item1);
                            tempOdabrani.Add(noviPar);
                            tempOdabraniReverse.Add(reverseKlub);
                            tempKlub.Add(noviPar.Item2);
                        }
                    }
                }
                
                DodajNoveUtakmice(tempOdabrani);
                DodajNoveUtakmice(tempOdabraniReverse);

                var rezultat = sviParovi.Except(tempOdabrani).ToList();
                sviParovi = rezultat;
                tempOdabrani.Clear();
                tempOdabraniReverse.Clear();
            }
        }

        private void DodajNoveUtakmice(List<(Klub, Klub)> parovi)
        {
            var postojiUtakmica = utakmice.Count != 0;
            var brojZadnjeUtakmice = postojiUtakmica ? utakmice.Last().Broj : 0;
            var sadasnjeKolo = postojiUtakmica ? utakmice.Last().Kolo + 1 : 1;
          
            foreach (var par in parovi)
            {
                brojZadnjeUtakmice++;
                var datum = DateTime.Parse(DateTime.Now.ToString("g"));
                var utakmica = new Utakmica(brojZadnjeUtakmice, sadasnjeKolo, par.Item1, par.Item2, datum);
                utakmice.Add(utakmica);
            }
        }

        public void SaveRaspored()
        {
            var caretaker = Caretaker.DohvatiCaretaker();
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();

            prvenstvo.AktivniRaspored.Broj = caretaker.ZadnjiRaspored() + 1;
            prvenstvo.AktivniRaspored.Datum = DateTime.Parse(DateTime.Now.ToString("G"));
            prvenstvo.AktivniRaspored.Utakmice = utakmice;
            caretaker.Backup(prvenstvo.AktivniRaspored.SaveRaspored());
        }
    }
}
