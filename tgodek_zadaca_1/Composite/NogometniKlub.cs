using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Composite
{
    public abstract class NogometniKlub
    {
        protected List<NogometniKlub> Komponente { get; set; } = new List<NogometniKlub>();
        public abstract void DetaljiKomponente();
    }

    public enum Pozicija
    {
        G, B, V, N, LB, DB, CB, LDV, DDV, CDV,
        LV, DV, CV, LOV, DOV, COV, LN, DN, CN
    }

    public class Igrac : NogometniKlub
    {
        public string Ime { get; set; }
        public Pozicija Pozicija { get; set; }
        public DateTime Datum { get; set; }

        public Igrac(Klub klub, string ime, Pozicija pozicija, DateTime datum)
        {
            this.Ime = ime;
            this.Pozicija = pozicija;
            this.Datum = datum;
            Komponente.Add(klub);
        }

        public override void DetaljiKomponente()
        {
            Console.WriteLine("Ime igraca: {0} Pozicija: {1} Rodenje: {2}",Ime, Pozicija, Datum);
            foreach (var komponenta in Komponente)
            {
                komponenta.DetaljiKomponente();
            }
        }
    }

    public class Trener : NogometniKlub
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Trener(string ime, string prezime)
        {
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public override void DetaljiKomponente()
        {
            Console.WriteLine("{0} {1}", Ime, Prezime);
        }
    }

    public class Klub : NogometniKlub
    {
        public string Oznaka { get; set; }
        public string Naziv { get; set; }

        public Klub(string oznaka, string naziv, Trener trener)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            Komponente.Add(trener);
        }

        public override void DetaljiKomponente()
        {
            Console.WriteLine("Oznaka kluba: {0}, Naziv kluba: {1}", Oznaka, Naziv);
            foreach (var komponenta in Komponente)
            {
                komponenta.DetaljiKomponente();
            }
        }
    }
}
