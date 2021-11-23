using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    abstract class NogometnaLiga
    {
    }

    class Liga : INogometniKlub
    {
        public List<INogometniKlub> liga { get; set; } = new List<INogometniKlub>();

        public void DetaljiKomponente()
        {
            foreach (var x in liga)
            {
                x.DetaljiKomponente();
            }
        }

        public INogometniKlub KomponentaPostoji(string id)
        {
            INogometniKlub postoji = null;
            foreach (var x in liga)
            {
                if (x.KomponentaPostoji(id) != null)
                    postoji = x.KomponentaPostoji(id);
            }
            return postoji;
        }
    }
}
