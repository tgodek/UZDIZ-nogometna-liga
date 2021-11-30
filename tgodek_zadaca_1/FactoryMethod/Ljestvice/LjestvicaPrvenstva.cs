using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_1.FactoryMethod.Ljestvice
{
    class LjestvicaPrvenstva : ILjestvica
    {
        private readonly int Kolo;
        private List<int> duljineZapisa;
        private readonly string[] naslovi = { "Naziv kluba", "Oznaka", "Trener", "Broj odigranih kola",
            "Broj pobjeda", "Broj neriješenih","Broj poraza","Broj danih golova", "Broj primljenih golova", "Razlika golova", "Broj bodova"};

        public LjestvicaPrvenstva(int kolo = 0)
        {
            Kolo = kolo;
        }

        public void Ispis()
        {
            duljineZapisa = naslovi.Select(i => i.Length).ToList();
            duljineZapisa[0] = duljineZapisa[0] * 2;
            duljineZapisa[2] = duljineZapisa[2] * 4;

            var liga = Prvenstvo.DohvatiPrvenstvo();
            var (klubovi, ukSuma) = liga.PripremljenaLjestvicaPrvenstva(Kolo);

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
                Console.Write("| " + klub.Naziv.PadRight(duljineZapisa[0]) + ' '
                    + "| " + klub.Oznaka.PadRight(duljineZapisa[1]) + ' '
                    + "| " + klub.Trener.Ime.PadRight(duljineZapisa[2]) + ' '
                    + "| " + klub.BrojOdigranihKola.ToString().PadLeft(duljineZapisa[3]) + ' '
                    + "| " + klub.BrojPobjeda.ToString().PadLeft(duljineZapisa[4]) + ' '
                    + "| " + klub.BrojNerješenih.ToString().PadLeft(duljineZapisa[5]) + ' '
                    + "| " + klub.BrojPoraza.ToString().PadLeft(duljineZapisa[6]) + ' '
                    + "| " + klub.BrojDanihGolova.ToString().PadLeft(duljineZapisa[7]) + ' '
                    + "| " + klub.BrojPrimljenihGolova.ToString().PadLeft(duljineZapisa[8]) + ' '
                    + "| " + klub.RazlikaGolova().ToString().PadLeft(duljineZapisa[9]) + ' '
                    + "| " + klub.BrojBodova.ToString().PadLeft(duljineZapisa[10]) + " |\n");
            }

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            Console.Write("| " + "Ukupno".PadRight(duljineZapisa[0]) + ' '
                  + "| " + "".PadRight(duljineZapisa[1]) + ' '
                  + "| " + "".PadRight(duljineZapisa[2]) + ' '
                  + "| " + "".PadRight(duljineZapisa[3]) + ' '
                  + "| " + ukSuma.SumaBrojaPobjeda.ToString().PadLeft(duljineZapisa[4]) + ' '
                  + "| " + ukSuma.SumaBrojaNerjesenih.ToString().PadLeft(duljineZapisa[5]) + ' '
                  + "| " + ukSuma.SumaBrojaPoraza.ToString().PadLeft(duljineZapisa[6]) + ' '
                  + "| " + ukSuma.SumaBrojaDanihGolova.ToString().PadLeft(duljineZapisa[7]) + ' '
                  + "| " + ukSuma.SumaBrojaPrimljenihGolova.ToString().PadLeft(duljineZapisa[8]) + ' '
                  + "| " + "".PadRight(duljineZapisa[9]) + ' '
                  + "| " + ukSuma.SumaBrojaBodova.ToString().PadLeft(duljineZapisa[10]) + " |\n");

            duljineZapisa.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");

            liga.Resetiraj();
        }

    }
}
