using System;
using System.Collections.Generic;

namespace tgodek_zadaca_1.Composite
{
    class Liga : INogometnaLiga
    {
        public List<INogometnaLiga> liga { get; set; } = new List<INogometnaLiga>();

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
    }
}
