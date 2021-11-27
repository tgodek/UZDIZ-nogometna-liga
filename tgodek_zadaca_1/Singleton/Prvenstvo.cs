using System;
using System.Collections.Generic;
using tgodek_zadaca_1.Composite;
using tgodek_zadaca_1.FactoryMethod.Ljestvice;
using tgodek_zadaca_1.Visitor;

namespace tgodek_zadaca_1
{
    class Prvenstvo : INogometnaLiga
    {
        protected List<INogometnaLiga> liga { get; set; } = new List<INogometnaLiga>();

        private static Prvenstvo instanca;
        private Prvenstvo() 
        {
        }

        public static Prvenstvo DohvatiPrvenstvo()
        {
            if (instanca == null)
            {
                instanca = new Prvenstvo();
            }
            return instanca;
        }

        public void DodajKomponentu(INogometnaLiga komponenta) => liga.Add(komponenta);

        public void DetaljiKomponente()
        {
            foreach (var x in liga)
            {
                x.DetaljiKomponente();
            }
        }

        public INogometnaLiga PronadiZapis(string id)
        {
            INogometnaLiga komponenta = null;
            foreach (var x in liga)
            {
                if (x.PronadiZapis(id) != null)
                    komponenta = x.PronadiZapis(id);
            }
            return komponenta;
        }

        public void IspisLjestvice(Izbornik izbornik)
        {
            try
            {
                var ljestvica = new LjestvicaFactory().DohvatiLjestvicu(izbornik.Zastavica, izbornik.Kolo);
                ljestvica.Ispis();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Nje implenetirano");
            }
        }

        public void Accept(IOperation operacija)
        {
            foreach (var komponenta in liga)
            {
                komponenta.Accept(operacija);
            }
        }

        public void ResetirajKlubove()
        {
            foreach (var klub in liga)
            {
                Klub _klub;
                if (klub.GetType() == typeof(Klub))
                {
                    _klub = (Klub)klub;
                    _klub.ResetirajKlub();
                }

            }
        }
    }
}
