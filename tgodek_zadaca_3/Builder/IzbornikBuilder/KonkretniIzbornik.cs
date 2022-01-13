﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3
{
    class KonkretniIzbornik : IIzbornik
    {
        Izbornik _izbornik = new Izbornik();

        public KonkretniIzbornik()
        {
            Reset();
        }

        public IIzbornik DodajZastavicu(string zastavica)
        {
            this._izbornik.Zastavica = zastavica;
            return this;
        }

        public IIzbornik DodajKolo(int kolo)
        {
            this._izbornik.Kolo = kolo;
            return this;
        }

        public IIzbornik DodajKlub(string klub)
        {
            this._izbornik.Klub = klub;
            return this;
        }

        public IIzbornik DodajKlub2(string klub)
        {
            this._izbornik.Klub2 = klub;
            return this;
        }

        public IIzbornik DodajSekunde(int sekunde)
        {
            this._izbornik.Sekunde = sekunde;
            return this;
        }


        private void Reset()
        {
            this._izbornik = new Izbornik();
        }

        public Izbornik Build()
        {
            Izbornik izbornik = this._izbornik;
            this.Reset();
            return izbornik;
        }

        public IIzbornik DodajSekunde(string klub)
        {
            throw new NotImplementedException();
        }
    }
}
