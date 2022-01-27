using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_3.Tablica
{
    class KlasicnaTablica 
    {
        private readonly string[] Naslovi;
        private readonly List<int> SirinaStupca;
        private readonly List<string[]> Zapisi;
        public List<int> Stupci { get { return SirinaStupca; } }

        public KlasicnaTablica(string[] naslovi) 
        {
            Zapisi = new List<string[]>();
            Naslovi = naslovi;
            SirinaStupca = Naslovi.Select(u => u.Length).ToList();
        }

        private void IspisiNaslov()
        {
            IspisiDivider();
            string naslov = "";
            for (int i = 0; i < Naslovi.Length; i++)
                naslov += "| " + Naslovi[i].PadRight(SirinaStupca[i]) + ' ';
            Console.Write(naslov + "|\n");
            IspisiDivider();
        }

        public void IspisiDivider() 
        {
            SirinaStupca.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");
        }

        public void IspisiPodnozje(List<Tuple<int, string>> podnozje)
        {
            Console.Write("| ");
            Console.Write("Ukupno".PadRight(SirinaStupca[0]) + " | ");
            for (int i = 1; i < Naslovi.Length; i++)
            {
                var pronaden = podnozje.Find(x => x.Item1 == i);
                if (pronaden != null)
                {
                    Console.Write(pronaden.Item2.PadLeft(SirinaStupca[i]) + " | ");
                }
                else
                {
                    Console.Write("".PadLeft(SirinaStupca[i]) + " | ");
                }
            }
            Console.Write("\n");
            IspisiDivider();
        }


        public void DodajRed(string[] red)
        {
            if (Naslovi.Length == red.Length) 
            {
                Zapisi.Add(red);
                for (int i = 0; i < SirinaStupca.Count; i++) 
                {
                    if (red[i].Length > SirinaStupca[i]) SirinaStupca[i] = red[i].Length;
                }
            }
        }

        public void Ispis()
        {
            IspisiNaslov();
            foreach (var redak in Zapisi)
            {
                Console.Write("| ");
                for (int i = 0; i < redak.Length; i++)
                {
                    if (int.TryParse(redak[i], out _))
                        Console.Write(redak[i].PadLeft(SirinaStupca[i]) + " | ");
                    else
                        Console.Write(redak[i].PadRight(SirinaStupca[i]) + " | ");
                }
                Console.Write("\n");
            }
            IspisiDivider();
        }
    }
}
