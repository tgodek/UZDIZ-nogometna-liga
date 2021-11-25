using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Model;

namespace tgodek_zadaca_1.FactoryMethod.Ljestvice
{
    public class LjestvicaKartoni : ILjestvica
    {
        private int Kolo { get; set; }
        public LjestvicaKartoni(int kolo)
        {
            this.Kolo = kolo; 
        }
        public void Ispis()
        {
            /*
            var prvenstvo = Prvenstvo.DohvatiPrvenstvo();
            var dogadaji = prvenstvo.SviDogadaji();
            var igraci = prvenstvo.SviIgraci();
            var utakmice = prvenstvo.SveUtakmice();
            var klubovi = prvenstvo.SviKlubovi();

            var zadnjaUtakmica = utakmice.FindLast(u => u.Kolo == Kolo);

            if (zadnjaUtakmica != null && Kolo != 0)
            {
                foreach (var dogadaj in dogadaji)
                {
                    foreach (var igrac in igraci)
                    {
                        foreach (var klub in klubovi)
                        {
                            if ((dogadaj.Vrsta == 10) && (dogadaj.Igrac == igrac.Ime) && 
                                (dogadaj.Broj <= zadnjaUtakmica.Broj) && 
                                (dogadaj.Klub == igrac.Klub && igrac.Klub == klub.Oznaka))
                            {
                                igrac.ZutiKarton += 1;
                            }
                            if ((dogadaj.Vrsta == 11) && (dogadaj.Igrac == igrac.Ime) && 
                                (dogadaj.Broj <= zadnjaUtakmica.Broj) && 
                                (dogadaj.Klub == igrac.Klub && igrac.Klub == klub.Oznaka))
                            {
                                igrac.CrveniKarton += 1;
                            }
                        }
                    }
                }
                foreach (var igrac in igraci)
                {
                    foreach (var klub in klubovi)
                    {
                        if ((igrac.ZutiKarton > 0) && igrac.Klub == klub.Oznaka)
                        {
                            klub.UkZutihKartona += 1;
                        }
                        if ((igrac.CrveniKarton > 0) && igrac.Klub == klub.Oznaka)
                        {
                            klub.UkCrvenihKartona += 1;
                        }
                    }
                }
                Console.WriteLine("\n-------------------------------------------- KARTONI -------------------------------------------------");
                Console.WriteLine("| {0,10} {1,25} {2,20} {3,20} {4,20}|", "Klub", "Oznaka kluba", "Zuti karton", "Crveni karton", "Ukupno kartona");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                foreach (var klub in klubovi)
                {
                    var UkKartona = klub.UkZutihKartona + klub.UkDrugihZutihKartona + klub.UkCrvenihKartona;
                    Console.WriteLine("{0,-20} {1,10} {2,20} {3,20} {4,20}", klub.Naziv, klub.Oznaka, klub.UkZutihKartona, klub.UkCrvenihKartona, UkKartona);
                    klub.ResetKartone();
                }
                foreach (var igrac in igraci)
                {
                    igrac.ResetIgracStat();
                }
            }*/
        }
    }
}
