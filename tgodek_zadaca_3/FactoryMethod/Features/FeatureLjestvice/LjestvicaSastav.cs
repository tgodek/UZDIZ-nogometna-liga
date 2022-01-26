using System;
using System.Linq;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;
using tgodek_zadaca_3.Tablica;

namespace tgodek_zadaca_3.Feature
{
    class LjestvicaSastav : Operacija
    {
        private readonly int Kolo;
        private readonly string DomacinOznaka;
        private readonly string GostOznaka;
        private readonly Prvenstvo prvenstvo;
        private readonly ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private readonly ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private readonly CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();
        private readonly string[] naslovi = { "Pozicija","Domaćin", "Pozicija","Gost" };

        public LjestvicaSastav(int kolo, string domacin, string gost)
        {
            prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            Kolo = kolo;
            DomacinOznaka = domacin;
            GostOznaka = gost;
            ZamjenaHandler.SetNextHandler(ZutKartonHandler).SetNextHandler(CrveniKartonHandler);
        }
        public override void ObradiZahtjev()
        {
            var utakmica = DohvatiUtakmicu();
            if (utakmica == null) return;
            OdrediPocetniSastav(utakmica);
            Console.WriteLine("\nPOČETAK UTAKMICE\n");
            IspisiSastav(utakmica);
            OdigrajUtakmicu(utakmica);
            Console.WriteLine("\nKRAJ UTAKMICE\n");
            IspisiSastav(utakmica);
            prvenstvo.Resetiraj();
        }

        private Utakmica DohvatiUtakmicu()
        {
            var domacin = prvenstvo.PronadiZapis(DomacinOznaka) as Klub;
            var gost = prvenstvo.PronadiZapis(GostOznaka) as Klub;
            if (domacin == null)
                Console.WriteLine("Klub s oznakom " + DomacinOznaka + " ne postoji");
            else if (gost == null)
                Console.WriteLine("Klub s oznakom " + GostOznaka + " ne postoji");
            else 
            {
                var utakmice = prvenstvo.GetUtakmice().Where(u => u.Kolo == Kolo).ToList();
                foreach (Utakmica utakmica in utakmice)
                {
                    if (utakmica.Kolo == Kolo && (utakmica.Domacin == domacin && utakmica.Gost == gost) ||
                        (utakmica.Domacin == gost && utakmica.Gost == domacin))
                    {
                        return utakmica;
                    }
                }
            }
            return null;
        }

        private void OdigrajUtakmicu(Utakmica utakmica)
        {
            var dogadaji = utakmica.Komponente.FindAll(e => e.GetType() == typeof(Dogadaj));
            foreach (Dogadaj dogadaj in dogadaji)
            {
                ZamjenaHandler.ProccessEvent(dogadaj);
            }
        }

        private void OdrediPocetniSastav(Utakmica utakmica)
        {
            var sastavi = utakmica.Komponente.FindAll(e => e.GetType() == typeof(SastavUtakmice));
            foreach (SastavUtakmice sastav in sastavi)
            {
                sastav.Igrac.OnPostava(sastav.Vrsta);
            }
        }

        private void IspisiSastav(Utakmica utakmica)
        {
            var tablica = new KlasicnaTablica(naslovi);

            var domacinIgraci = utakmica.Domacin.ListaIgraca().FindAll(i => i.IgracUIgri()).OrderBy(i => i.Pozicija).ToList();
            var gostigraci = utakmica.Gost.ListaIgraca().FindAll(i => i.IgracUIgri()).OrderBy(i => i.Pozicija).ToList();
            var brojZapisaD = domacinIgraci.Count;
            var brojZapisaG = gostigraci.Count;
            int razlika = 0;
            if (brojZapisaD > brojZapisaG)
            {
                razlika = brojZapisaD - brojZapisaG;
                for (int i = 0; i < razlika; i++)
                {
                    var igrac = new Igrac(new Klub("", "", new Trener("")),"-",Pozicija.NAN,DateTime.Now);
                    gostigraci.Add(igrac);
                }
            }
            else if (brojZapisaG > brojZapisaD) 
            {
                razlika = brojZapisaG - brojZapisaD;
                for (int i = 0; i < razlika; i++)
                {
                    var igrac = new Igrac(new Klub("", "", new Trener("")), "-", Pozicija.NAN, DateTime.Now);
                    domacinIgraci.Add(igrac);
                }
            }

            for (int i = 0; i < brojZapisaD; i++)
            {
                var domacinPozicija = domacinIgraci[i].Pozicija.ToString();
                var domacinIme = domacinIgraci[i].Ime;
                var gostPozicija = gostigraci[i].Pozicija.ToString();
                var gostIme = gostigraci[i].Ime;

                if (domacinIgraci[i].Pozicija == Pozicija.NAN)
                    domacinPozicija = "-";
                if (gostigraci[i].Pozicija == Pozicija.NAN)
                    gostPozicija = "-";
                
                string[] zapis = { domacinPozicija, domacinIme, gostPozicija, gostIme };
                tablica.DodajRedak(zapis);
            }
            tablica.Ispis();
        }

      
    }
}
