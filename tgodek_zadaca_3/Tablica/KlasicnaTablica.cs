using System;
using System.Collections.Generic;
using System.Linq;

namespace tgodek_zadaca_3.Tablica
{
    class KlasicnaTablica 
    {
        private readonly string[] Naslovi;
        private readonly List<int> DuljineStupca;
        private List<string[]> Zapisi;

        public KlasicnaTablica(string[] naslovi) 
        {
            Zapisi = new List<string[]>();
            Naslovi = naslovi;
            DuljineStupca = Naslovi.Select(u => u.Length).ToList();
        }

        private void IspisiNaslov()
        {
            IspisiDivider();

            string naslov = "";
            for (int i = 0; i < Naslovi.Length; i++)
                naslov += "| " + Naslovi[i].PadRight(DuljineStupca[i]) + ' ';
            Console.Write(naslov + "|\n");

            IspisiDivider();
        }

        private void IspisiDivider() 
        {
            DuljineStupca.ForEach(l => Console.Write("--" + new string('-', l) + '-'));
            Console.Write("-\n");
        }

        public void IspisiPodnozje()
        {
        }


        public void DodajRedak(string[] redak)
        {
            if (Naslovi.Length == redak.Length)
                Zapisi.Add(redak);
        }

        private void OdrediDuljinuStupca()
        {
            foreach (var redak in Zapisi)
            {
                for (int i = 0; i < redak.Length; i++)
                {
                    if (redak[i].Length >= DuljineStupca[i])
                        DuljineStupca[i] = redak[i].Length;
                }
            }
        }

        public void Ispis()
        {
            OdrediDuljinuStupca();
            IspisiNaslov();
            foreach (var redak in Zapisi)
            {
                Console.Write("| ");
                for (int i = 0; i < redak.Length; i++)
                {
                    if (int.TryParse(redak[i], out _))
                        Console.Write(redak[i].PadLeft(DuljineStupca[i]) + " | ");
                    else
                        Console.Write(redak[i].PadRight(DuljineStupca[i]) + " | ");
                }
                Console.Write("\n");
            }
            IspisiDivider();
        }
    }
}
