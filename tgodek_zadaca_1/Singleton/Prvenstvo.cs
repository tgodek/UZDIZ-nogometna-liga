﻿using System;
using System.Collections.Generic;
using tgodek_zadaca_1.Composite;
using tgodek_zadaca_1.FactoryMethod.Ljestvice;
using tgodek_zadaca_1.Visitor;
using System.Linq;

namespace tgodek_zadaca_1
{
    class Prvenstvo : INogometnaLiga
    {
        protected List<INogometnaLiga> liga { get; set; } = new List<INogometnaLiga>();

        private static Prvenstvo instanca;
        private Prvenstvo() 
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

        public void DodajKomponentu(INogometnaLiga komponenta) => liga.Add(komponenta);

        public void DetaljiKomponente()
        {
            foreach (var x in liga)
            {
                x.DetaljiKomponente();
            }
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            foreach (var x in liga)
            {
                if (x.PronadiZapis(id) != null)
                    komponenta = x.PronadiZapis(id);
            }
            return komponenta;
        }

        public void IspisLjestvice(Izbornik izbornik)
        {
            if (!String.IsNullOrEmpty(izbornik.Klub))
            {
                var ljestvica = new LjestvicaRezultata(izbornik.Klub, izbornik.Kolo);
                if (ljestvica != null)
                    ljestvica.Ispis();
            }
            else
            {
                var ljestvica = new LjestvicaFactory().DohvatiLjestvicu(izbornik.Zastavica, izbornik.Kolo);
                if(ljestvica != null)
                    ljestvica.Ispis();
            }
        }

        public void Accept(IOperation operacija)
        {
            foreach (var komponenta in liga)
            {
                komponenta.Accept(operacija);
            }
        }

        internal (List<Igrac>, int) PripremljenaLjestvicaStrijelaca(int kolo)
        {
            List<Igrac> igraci = new List<Igrac>();
            var operacija = new GetTablicaStrijelci(kolo);
            this.Accept(operacija);
            foreach (var klub in liga)
            {
                Klub _klub;
                if (klub.GetType() == typeof(Klub))
                {
                    _klub = (Klub)klub;
                    var _igraci = _klub.ListaIgraca();
                    foreach (var igrac in _igraci)
                    {
                        if (igrac.BrojPogodaka > 0)
                            igraci.Add(igrac);
                    }
                }
            }
            return (igraci.OrderByDescending(i => i.BrojPogodaka).ToList(), operacija.Result);
        }

        internal (List<Klub>, SumaKartona suma) PripremljenaLjestvicaKartona(int kolo)
        {
            List<Klub> klubovi = new List<Klub>();
            var operacija = new GetTablicaKartona(kolo);
            this.Accept(operacija);
            foreach (var klub in liga)
            {
                Klub _klub;
                if (klub.GetType() == typeof(Klub))
                {
                    _klub = (Klub) klub;
                    if(_klub.UkupnoKartona() > 0)
                        klubovi.Add(_klub);
                }
            }
            return (klubovi.OrderByDescending(k => k.UkupnoKartona())
                .ThenByDescending(k => k.CrveniKarton)
                .ThenByDescending(k => k.DrugiZutiKarton)
                .ToList(), operacija.Result);
        }

        internal (List<Klub>,SumaLjestvicePrvenstva) PripremljenaLjestvicaPrvenstva(int kolo)
        {
            List<Klub> klubovi = new List<Klub>();
            var operacija = new GetTablicaPrvenstva(kolo);
            this.Accept(operacija);
            foreach (var klub in liga)
            {
                Klub _klub;
                if (klub.GetType() == typeof(Klub))
                {
                    _klub = (Klub)klub;
                    klubovi.Add(_klub);
                }
            }
            return (klubovi.OrderByDescending(k => k.BrojBodova)
                .ThenByDescending(k => k.RazlikaGolova())
                .ThenByDescending(k => k.BrojDanihGolova)
                .ThenByDescending(k => k.BrojPobjeda)
                .ToList(), operacija.Result);
        }


        internal List<Utakmica> PripremljenaLjestvicaRezultata(string klub, int kolo)
        {
            List<Utakmica> utakmice = new List<Utakmica>();
            var operacija = new GetTablicaRezultata(klub, kolo);
            this.Accept(operacija);
            foreach (var utakmica in liga)
            {
                Utakmica _utakmica;
                if (utakmica.GetType() == typeof(Utakmica))
                {
                    _utakmica = (Utakmica)utakmica;
                    if(_utakmica.Odigrana == true)
                        utakmice.Add(_utakmica);
                }
            }
            return utakmice;
        }

        public void Resetiraj()
        {

            foreach (var komponenta in liga)
            {
                Klub _klub;
                Utakmica _utakmica;

                if (komponenta.GetType() == typeof(Utakmica))
                {
                    _utakmica = (Utakmica)komponenta;
                    _utakmica.ResetirajUtakmicu();
                }

                if (komponenta.GetType() == typeof(Klub))
                {
                    _klub = (Klub)komponenta;
                    _klub.ResetirajKlub();
                    _klub.ResetIgrace();
                }
            }
        }
    }
}
