using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tgodek_zadaca_2.Ljestvice
{
    class LjestvicaRezultata
    {
        private readonly int Kolo;
        private readonly string OznakaKluba;
        private List<int> duljineZapisa;
        private readonly string[] naslovi = { "Kolo", "Datum i vrijeme", "Klub domaćin", "Klub gost", "Rezultat" };

        public LjestvicaRezultata(string oznakaKluba, int kolo = 0)
        {
            this.OznakaKluba = oznakaKluba;
            this.Kolo = kolo;
        }

        public void Ispis()
        {
            duljineZapisa = naslovi.Select(u => u.Length).ToList();
            var liga = Prvenstvo.DohvatiPrvenstvo();
            var utakmice = liga.PripremljenaLjestvicaRezultata(OznakaKluba,Kolo);

            foreach (var uk in utakmice)
            {
                if (duljineZapisa[1] < uk.Pocetak.ToString().Length)
                    duljineZapisa[1] = uk.Pocetak.ToString().Length;
                if (duljineZapisa[2] < uk.Domacin.Naziv.Length)
                    duljineZapisa[2] = uk.Domacin.Naziv.Length;
                if (duljineZapisa[3] < uk.Gost.Naziv.Length)
                    duljineZapisa[3] = uk.Gost.Naziv.Length;
                if (duljineZapisa[4] < uk.RezultatUtakmice().Length)
                    duljineZapisa[4] = uk.RezultatUtakmice().Length;
            }

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            string naslov = "";
            for (int i = 0; i < naslovi.Length; i++)
                naslov += "| " + naslovi[i].PadRight(duljineZapisa[i]) + ' ';
            Console.Write(naslov + "|\n");

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            foreach (var utakmica in utakmice)
            {
                Console.Write("| " + utakmica.Kolo.ToString().PadLeft(duljineZapisa[0]) + ' '
                    + "| " + utakmica.Pocetak.ToString().PadLeft(duljineZapisa[1]) + ' '
                    + "| " + utakmica.Domacin.Naziv.PadRight(duljineZapisa[2]) + ' '
                    + "| " + utakmica.Gost.Naziv.ToString().PadRight(duljineZapisa[3]) + ' '
                    + "| " + utakmica.RezultatUtakmice().PadLeft(duljineZapisa[4]) + " |\n");
            }

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            liga.Resetiraj();
        }
    }
}
