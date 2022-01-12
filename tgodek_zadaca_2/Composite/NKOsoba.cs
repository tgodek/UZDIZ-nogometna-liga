using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_2.Visitor;

namespace tgodek_zadaca_2.Composite
{
    public abstract class NKOsoba
    {
        public string Ime;
    }

    public enum Pozicija
    {
        G, B, V, N, LB, DB, CB, LDV, DDV, CDV,
        LV, DV, CV, LOV, DOV, COV, LN, DN, CN
    }

    public class Igrac : NKOsoba, INogometnaLiga
    {
        public Pozicija Pozicija { get; set; }
        public DateTime Datum { get; set; }
        public Klub Klub { get; set; }

        public int ZutiKarton { get; set; }
        public int DrugiZutiKarton { get; set; }
        public int CrveniKarton { get; set; }
        public int BrojPogodaka { get; set; }

        public Igrac(Klub klub, string ime, Pozicija pozicija, DateTime datum)
        {
            this.Klub = klub;
            this.Ime = ime;
            this.Pozicija = pozicija;
            this.Datum = datum;
        }

        public void ResetStatistiku()
        {
            this.CrveniKarton = 0;
            this.ZutiKarton = 0;
            this.DrugiZutiKarton = 0;
            this.BrojPogodaka = 0;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == this.Ime)
                return this;
            else
                return null;
        }

        public void Accept(IOperation operacija)
        {
            operacija.Visit(this);
        }
    }

    public class Trener : NKOsoba, INogometnaLiga
    {
        public Trener(string ime)
        {
            this.Ime = ime;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == this.Ime)
                return this;
            else
                return null;
        }

        public void Accept(IOperation operacija)
        {
            operacija.Visit(this);
        }
    }
}
