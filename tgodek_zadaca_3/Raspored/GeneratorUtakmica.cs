using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3.Raspored
{
    class GeneratorUtakmica
    {
        private int Algoritam;
        private List<int> Kola;


        public GeneratorUtakmica(int algoritam) 
        {
            Algoritam = algoritam;
        }

        public void GenerirajPremaAlgoritmu() 
        {
            switch (Algoritam) 
            {
                case 1: 
                    {
                        var algoritam1 = new AlgoritamSlucajniBrojevi();
                        algoritam1.Generiraj();
                    } break;
            }
        }
    }
}
