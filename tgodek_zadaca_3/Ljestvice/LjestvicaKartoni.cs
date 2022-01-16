using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_3.Ljestvice
{
    public class LjestvicaKartoni
    {
        private readonly int Kolo;
        private List<int> duljineZapisa;
        private readonly string[] naslovi = { "Klub", "Oznaka Kluba", "Zuti Karton", "Drugi zuti karton", "Crveni karton", "Ukupno" };
        public LjestvicaKartoni(int kolo = 0)
        {
            this.Kolo = kolo; 
        }
        public void Ispis()
        {
            duljineZapisa = naslovi.Select(k => k.Length).ToList();
            duljineZapisa[0] = duljineZapisa[0] * 8;

            var liga = Prvenstvo.DohvatiPrvenstvo();
            var (klubovi, ukSuma) = liga.PripremljenaLjestvicaKartona(Kolo);

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            string naslov = "";
            for (int i = 0; i < naslovi.Length; i++)
                naslov += "| " + naslovi[i].PadRight(duljineZapisa[i]) + ' ';
            Console.Write(naslov + "|\n");

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            foreach (var klub in klubovi)
            {
                Console.Write( "| " + klub.Naziv.PadRight(duljineZapisa[0]) + ' '
                    + "| " + klub.Oznaka.PadRight(duljineZapisa[1]) + ' '
                    + "| " + klub.ZutiKarton.ToString().PadLeft(duljineZapisa[2]) + ' '
                    + "| " + klub.DrugiZutiKarton.ToString().PadLeft(duljineZapisa[3]) + ' '
                    + "| " + klub.CrveniKarton.ToString().PadLeft(duljineZapisa[4]) + ' '
                    + "| " + klub.UkupnoKartona().ToString().PadLeft(duljineZapisa[5]) + " |\n");
            }
            
            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            Console.Write("| " + "".PadRight(duljineZapisa[0]) + ' '
                + "| " + "Ukupno".PadRight(duljineZapisa[1]) + ' '
                + "| " + ukSuma.UkZutih.ToString().PadLeft(duljineZapisa[2]) + ' '
                + "| " + ukSuma.UkDrugihZutih.ToString().PadLeft(duljineZapisa[3]) + ' '
                + "| " + ukSuma.UkCrvenih.ToString().PadLeft(duljineZapisa[4]) + ' '
                + "| " + ukSuma.Ukupno().ToString().PadLeft(duljineZapisa[5]) + " |\n");
            
            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");
            liga.Resetiraj();
        }
    }
}
