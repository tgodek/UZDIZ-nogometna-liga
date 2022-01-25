using tgodek_zadaca_3.Strategy;

namespace tgodek_zadaca_3.Feature
{
    class GeneratorRasporeda : Operacija
    {
        private readonly int Algoritam;

        public GeneratorRasporeda(int algoritam) 
        {
            Algoritam = algoritam;
        }

        public override void ObradiZahtjev()
        {
            var context = new RasporedContext();
            if(Algoritam == 1) context.PostaviStrategy(new AlgoritamSlucajniBrojevi());
            if(Algoritam == 2) context.PostaviStrategy(new AlgoritamAbecedno());
            if(Algoritam == 3) context.PostaviStrategy(new AlgoritamKlubTrener());
            context.PohraniRaspored();
        }
    }
}
