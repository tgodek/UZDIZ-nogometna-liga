using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Model
{
    class Klub
    {
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }
        public int UkZutihKartona { get; set; }
        public int UkDrugihZutihKartona { get; set; }
        public int UkCrvenihKartona { get; set; }

        private Klub(string oznaka, string naziv, string trener) 
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Trener = trener;
        }

        public void ResetKartone()
        {
            this.UkZutihKartona = 0;
            this.UkDrugihZutihKartona = 0;
            this.UkCrvenihKartona = 0;
        }

        static public Klub ProvjeriKlub(string oznaka, string naziv, string trener)
        {
            var klubError = "";
            
            if (String.IsNullOrEmpty(oznaka))
            {
                klubError += "-- Klub nema oznaku";
            }
            
            if (String.IsNullOrEmpty(naziv))
            {
                klubError = "-- Klub nema naziv";
            } 
            
            if (String.IsNullOrEmpty(trener))
            {
                klubError = "-- Klub nema trenera";
            }
       
            if (klubError == "")
            {
                var klub = new Klub(oznaka,naziv,trener);
                return klub;
            }
            else
            {
                Console.WriteLine("KLUB | Preskacem klub | Razlog: {0} | {1} {2} {3}", klubError, oznaka, naziv, trener);
                return null;
            }
        }
    }
}
