using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3.Feature
{
    public class FactoryFeature
    {
        public static Operacija GetFeature(Izbornik izbornik) 
        {
            switch (izbornik.Zastavica)
            {
                case "K": return new LjestvicaKartoni(izbornik.Kolo);
                case "S": return new LjestvicaStrijelci(izbornik.Kolo);
                case "T": return new LjestvicaPrvenstva(izbornik.Kolo);
                case "R": return new LjestvicaRezultata(izbornik.Klub,izbornik.Kolo);
                case "SU": return new LjestvicaSastav(izbornik.Kolo, izbornik.Klub, izbornik.Klub2);
                case "GR": return new GeneratorRasporeda(izbornik.Broj);
                case "IR": return new RasporedZaKlub(izbornik.Klub);
                case "IK": return new RasporedZaKolo(izbornik.Kolo);
                case "IG": return new PohranjeniRasporedi();
                case "VR": return new VazeciRaspored(izbornik.Broj);
                default: return null;
            }
        }
    }
}
