﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Composite
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
        public INogometnaLiga Klub { get; set; }

        public Igrac(string ime, Pozicija pozicija, DateTime datum)
        {
            this.Ime = ime;
            this.Pozicija = pozicija;
            this.Datum = datum;
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("    |-- Ime igraca: {0} Pozicija: {1} Rodenje: {2}", Ime, Pozicija, Datum.Date);
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == this.Ime)
                return this;
            else
                return null;
        }
    }

    public class Trener : NKOsoba, INogometnaLiga
    {
        public Trener(string ime)
        {
            this.Ime = ime;
        }

        public void DetaljiKomponente()
        {
            Console.WriteLine("Ime trenera: {0}", Ime);
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            if (id == this.Ime)
                return this;
            else
                return null;
        }
    }
}
