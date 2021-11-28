using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_1.FactoryMethod.Ljestvice
{
    public class LjestvicaStrijelci : ILjestvica
    {
        private readonly int Kolo;
        private List<int> duljineZapisa;
        private readonly string[] naslovi = { "Igrac", "Broj golova", "Naziv kluba", "Oznaka kluba" };

        public LjestvicaStrijelci(int kolo) 
        {
            this.Kolo = kolo;
        }

        public void Ispis()
        {
            duljineZapisa = naslovi.Select(i => i.Length).ToList();
            duljineZapisa[0] = duljineZapisa[0] * 6;
            duljineZapisa[2] = duljineZapisa[2] * 3;

            var liga = Prvenstvo.DohvatiPrvenstvo();
            var (igraci, ukSuma) = liga.PripremljenaTablicaStrijelaca(Kolo);

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            string naslov = "";
            for (int i = 0; i < naslovi.Length; i++)
                naslov += "| " + naslovi[i].PadRight(duljineZapisa[i]) + ' ';
            Console.Write(naslov + "|\n");

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            foreach (var igrac in igraci)
            {
                Console.Write("| " + igrac.Ime.ToString().PadRight(duljineZapisa[0]) + ' '
                    + "| " + igrac.BrojPogodaka.ToString().PadLeft(duljineZapisa[1]) + ' '
                    + "| " + igrac.Klub.Naziv.PadRight(duljineZapisa[2]) + ' '
                    + "| " + igrac.Klub.Oznaka.PadRight(duljineZapisa[3]) + " |\n");
            }

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            Console.Write("| " + "Ukupno".PadRight(duljineZapisa[0]) + ' '
                + "| " + ukSuma.ToString().PadLeft(duljineZapisa[1]) + ' '
                + "| " + "".PadLeft(duljineZapisa[2]) + ' '
                + "| " + "".ToString().PadLeft(duljineZapisa[3]) + " |\n");

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            liga.Resetiraj();
        }
    }

}
