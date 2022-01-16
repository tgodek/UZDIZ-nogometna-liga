using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using tgodek_zadaca_3.Chain;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Raspored
{
    class RasporedSastav
    {
        private int _kolo;
        private Klub Domacin;
        private Klub Gost;
        private ZamjenaHandler ZamjenaHandler = new ZamjenaHandler();
        private ZutiKartonHandler ZutKartonHandler = new ZutiKartonHandler();
        private CrveniKartonHandler CrveniKartonHandler = new CrveniKartonHandler();

        public RasporedSastav(int kolo, Klub domacin, Klub gost)
        {
            _kolo = kolo;
            Domacin = domacin;
            Gost = gost;
            ZamjenaHandler.SetNextHandler(ZutKartonHandler).SetNextHandler(CrveniKartonHandler);
        }

        public void Sastav()
        {
            var liga = Prvenstvo.DohvatiPrvenstvo();
            var utakmica = DohvatiUtakmicu(liga);
            if (utakmica == null) return;
            OdrediPocetniSastav(utakmica);
            Console.WriteLine("\nPOČETAK UTAKMICE\n");
            IspisiSastav(utakmica);
            OdigrajUtakmicu(utakmica);
            Console.WriteLine("\nKRAJ UTAKMICE\n");
            IspisiSastav(utakmica);
            liga.Resetiraj();
        }

        private Utakmica DohvatiUtakmicu(Prvenstvo liga)
        {
            var utakmice = liga.GetLiga().FindAll(e => e.GetType() == typeof(Utakmica));
            var postojiKolo = utakmice.Select(u => u as Utakmica).Where(u => u.Kolo == _kolo).ToList();
            foreach (Utakmica utakmica in utakmice)
            {
                if (utakmica.Kolo == _kolo && (utakmica.Domacin == Domacin && utakmica.Gost == Gost) ||
                    (utakmica.Domacin == Gost && utakmica.Gost == Domacin))
                {
                    return utakmica;
                }
            }
            return null;
        }

        private void OdigrajUtakmicu(Utakmica utakmica)
        {
            var dogadaji = utakmica.komponente.FindAll(e => e.GetType() == typeof(Dogadaj));
            foreach (Dogadaj dogadaj in dogadaji)
            {
                ZamjenaHandler.ProccessEvent(dogadaj);
            }
        }

        private void OdrediPocetniSastav(Utakmica utakmica)
        {
            var sastavi = utakmica.komponente.FindAll(e => e.GetType() == typeof(SastavUtakmice));
            foreach (SastavUtakmice sastav in sastavi)
            {
                sastav.Igrac.OnPostava(sastav.Vrsta);
            }
        }

        private void IspisiSastav(Utakmica utakmica)
        {
            var domacinIgraci = utakmica.Domacin.ListaIgraca().FindAll(i => i.IgracUIgri()).OrderBy(i => i.Pozicija).ToList();
            var gostigraci = utakmica.Gost.ListaIgraca().FindAll(i => i.IgracUIgri()).OrderBy(i => i.Pozicija).ToList();
            var brojZapisaD = domacinIgraci.Count;
            var brojZapisaG = gostigraci.Count;
            int brojZapisa = 0;
            if (brojZapisaD > brojZapisaG)
                brojZapisa = brojZapisaG;
            else if (brojZapisaG > brojZapisaD) 
                brojZapisa = brojZapisaD;
            else
                brojZapisa = brojZapisaD;

            List<int> duljineStupaca = new List<int>();
            duljineStupaca.Add(utakmica.Domacin.Naziv.Length * 3);
            duljineStupaca.Add(utakmica.Gost.Naziv.Length * 3);
            Console.WriteLine(utakmica.Domacin.Naziv.PadRight(duljineStupaca[0]) + "   " + utakmica.Gost.Naziv.PadRight(duljineStupaca[1]) + "\n");
            for (int i = 0; i < brojZapisa; i++)
            {
                string domacinZapis = domacinIgraci[i].Pozicija + " " + domacinIgraci[i].Ime;
                string gostZapis = gostigraci[i].Pozicija + " " + gostigraci[i].Ime;
                Console.WriteLine(domacinZapis.PadRight(duljineStupaca[0]) + " | " + gostZapis.PadRight(duljineStupaca[1]));
            }
        }
    }
}
