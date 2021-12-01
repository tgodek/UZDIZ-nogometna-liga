using System;
using System.Collections.Generic;
using tgodek_zadaca_2.Visitor;

namespace tgodek_zadaca_2.Composite
{
    public class Klub : INogometnaLiga
    {
        protected List<Igrac> igraci = new List<Igrac>();
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public Trener Trener { get; set; }
        public int ZutiKarton { get; set; }
        public int DrugiZutiKarton { get; set; }
        public int CrveniKarton { get; set; }
        public int BrojPobjeda { get; set; }
        public int BrojPoraza { get; set; }
        public int BrojNerješenih { get; set; }
        public int BrojDanihGolova { get; set; }
        public int BrojPrimljenihGolova { get; set; }
        public int BrojOdigranihKola { get; set; }
        public int BrojBodova { get; set; }

        public int RazlikaGolova()
        {
            return BrojDanihGolova - BrojPrimljenihGolova;
        }

        public int UkupnoKartona()
        {
            return ZutiKarton + DrugiZutiKarton + CrveniKarton;
        }

        public void DodajKomponentu(Igrac igrac)
        {
            igraci.Add(igrac);
        }

        public Klub(string oznaka, string naziv, Trener trener)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Trener = trener;
        }

        public void ResetirajKlub()
        {
            ZutiKarton = 0;
            DrugiZutiKarton = 0;
            CrveniKarton = 0;
            BrojPobjeda = 0;
            BrojPoraza = 0;
            BrojNerješenih = 0;
            BrojDanihGolova = 0;
            BrojPrimljenihGolova = 0;
            BrojOdigranihKola = 0;
            BrojBodova = 0;
        }

        public void ResetIgrace()
        {
            foreach (var igrac in igraci)
            {
                igrac.ResetStatistiku();
            }
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("  |-- Oznaka kluba: {0}, Naziv kluba: {1} Trener: {2} ZutiKarton: {3} Drugi Zuti: {4}", Oznaka, Naziv, Trener.Ime, ZutiKarton, DrugiZutiKarton);
            foreach (var x in igraci)
            {
                x.DetaljiKomponente();
            }
        }

        public List<Igrac> ListaIgraca()
        {
            return igraci;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            if (id == Oznaka)
                komponenta = this;
            else
            {
                foreach (var x in igraci)
                {
                    if (x.PronadiZapis(id) != null)
                        komponenta = x.PronadiZapis(id);
                }
            }
            return komponenta;
        }

        public Igrac IgracPostoji(string ime)
        {
            Igrac pronadenIgrac = null;
            foreach (var igrac in igraci)
            {
                if (ime == igrac.Ime)
                {
                    pronadenIgrac = igrac;
                    return pronadenIgrac;
                }
            }
            return pronadenIgrac;
        }

        public void Accept(IOperation operacija)
        {
            operacija.Visit(this);
            foreach (var igrac in igraci)
            {
                igrac.Accept(operacija);
            }
        }
    }
}
