using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.StatePattern;
using tgodek_zadaca_3.Visitor;

namespace tgodek_zadaca_3.Composite
{
    public abstract class NKOsoba
    {
        public string Ime;
    }

    public enum Pozicija
    {
        G, B, LB, DB, CB, V, LDV, DDV, CDV, LV,
       DV, CV, LOV, DOV, COV, N, LN, DN, CN, NAN
    }

    public class Igrac : NKOsoba, INogometnaLiga
    {
        public Pozicija Pozicija { get; set; }
        public DateTime Datum { get; set; }
        public Klub Klub { get; set; }
        private State _state = new Idle();

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

        public void SetState(State state) => _state = state;

        public string GetState() => _state.GetState();

        public void OnZamjena() => _state.OnZamjena(this);

        public void OnIskljucenje() => _state.OnIskljucenje(this);

        public void OnPostava(string postava) => _state.OnPostava(this, postava);

        public bool IgracUIgri() => _state.IgracUIgri();

        public void ResetirajState() => _state = new Idle();

        public void ResetirajKartone()
        {
            this.CrveniKarton = 0;
            this.ZutiKarton = 0;
            this.DrugiZutiKarton = 0;
        }

        public void ResetirajGolove() 
        {
            this.BrojPogodaka = 0;
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == this.Ime)
                return this;
            else
                return null;
        }

        public void Accept(IVisit operacija)
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

        public void Accept(IVisit operacija)
        {
            operacija.Visit(this);
        }
    }
}
