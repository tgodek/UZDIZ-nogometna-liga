using System;
using System.Linq;
using System.Collections.Generic;
using tgodek_zadaca_3.Composite;
using tgodek_zadaca_3.Visitor;
using tgodek_zadaca_3.Memento;
using tgodek_zadaca_3.Feature;
using tgodek_zadaca_3.Util;

namespace tgodek_zadaca_3
{
    class Prvenstvo : INogometnaLiga
    {
        public List<INogometnaLiga> Liga { get; private set; } = new List<INogometnaLiga>();

        private static Prvenstvo instanca;
        private Prvenstvo() { }

        public Originator AktivniRaspored = new Originator();

        public static Prvenstvo DohvatiPrvenstvo()
        {
            if (instanca == null)
            {
                instanca = new Prvenstvo();
            }
            return instanca;
        }

        public void DodajKomponentu(INogometnaLiga komponenta) => Liga.Add(komponenta);
       
        public List<Klub> GetKlubovi() => Liga.Where(e => e.GetType() == typeof(Klub)).Select(e => e as Klub).ToList();

        public List<Utakmica> GetUtakmice() => Liga.Where(e => e.GetType() == typeof(Utakmica)).Select(e => e as Utakmica).ToList();


        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            foreach (var x in Liga)
            {
                if (x.PronadiZapis(id) != null)
                    return komponenta = x.PronadiZapis(id);
            }
            return komponenta;
        }

        public void ObradiZahtjev(Izbornik izbornik)
        {
            var feature = FactoryFeature.GetFeature(izbornik);
            if(feature != null) feature.ObradiZahtjev();
        }

        public void Accept(IVisit operacija)
        {
            foreach (var komponenta in Liga)
            {
                komponenta.Accept(operacija);
            }
        }

        internal (List<Igrac>, int) PripremljenaLjestvicaStrijelaca(int kolo)
        {
            List<Igrac> strijelci = new List<Igrac>();
            var operacija = new GetTablicaStrijelci(kolo);
            this.Accept(operacija);
            var ukupnoPogodaka = 0;
            
            GetKlubovi().ForEach(k => strijelci.AddRange(k.ListaIgraca().FindAll(i => i.BrojPogodaka > 0)));
            ukupnoPogodaka = strijelci.Sum(i => i.BrojPogodaka);
            return (strijelci.OrderByDescending(i => i.BrojPogodaka).ToList(), ukupnoPogodaka);
        }

        internal (List<Klub>, SumaKartona suma) PripremljenaLjestvicaKartona(int kolo)
        {
            var operacija = new GetTablicaKartona(kolo);
            this.Accept(operacija);

            var sumaKartona = new SumaKartona();
            sumaKartona.UkZutih = GetKlubovi().Sum(k => k.ZutiKarton);
            sumaKartona.UkDrugihZutih = GetKlubovi().Sum(k => k.DrugiZutiKarton);
            sumaKartona.UkCrvenih = GetKlubovi().Sum(k => k.CrveniKarton);

            return (GetKlubovi().OrderByDescending(k => k.UkupnoKartona())
                .ThenByDescending(k => k.CrveniKarton)
                .ThenByDescending(k => k.DrugiZutiKarton)
                .ToList(), sumaKartona);
        }

        internal (List<Klub>,SumaLjestvicePrvenstva) PripremljenaLjestvicaPrvenstva(int kolo)
        {
            var operacija = new GetTablicaPrvenstva(kolo);
            this.Accept(operacija);

            var suma = new SumaLjestvicePrvenstva();
            suma.SumaBrojaPobjeda = GetKlubovi().Sum(k => k.BrojPobjeda);
            suma.SumaBrojaNerjesenih = GetKlubovi().Sum(k => k.BrojNerješenih);
            suma.SumaBrojaPoraza = GetKlubovi().Sum(k => k.BrojPoraza);
            suma.SumaBrojaDanihGolova = GetKlubovi().Sum(k => k.BrojDanihGolova);
            suma.SumaBrojaPrimljenihGolova = GetKlubovi().Sum(k => k.BrojPrimljenihGolova);
            suma.SumaBrojaBodova = GetKlubovi().Sum(k => k.BrojBodova);
         
            return (GetKlubovi().OrderByDescending(k => k.BrojBodova)
                .ThenByDescending(k => k.RazlikaGolova())
                .ThenByDescending(k => k.BrojDanihGolova)
                .ThenByDescending(k => k.BrojPobjeda)
                .ToList(), suma);
        }

        internal List<Utakmica> PripremljenaLjestvicaRezultata(string klub, int kolo)
        {
            var operacija = new GetTablicaRezultata(klub, kolo);
            this.Accept(operacija);
           
            return GetUtakmice().Where(u => u.Odigrana == true).ToList();
        }
        
        internal void Resetiraj()
        {
            foreach (var klub in GetKlubovi())
            {
                klub.ResetirajKlub();
                klub.ResetIgrace();
            }

            foreach (var utakmica in GetUtakmice())
            {
                utakmica.ResetirajUtakmicu();
            }
        }
    }
}
