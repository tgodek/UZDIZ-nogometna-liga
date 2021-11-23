﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_1.Composite
{
    public interface INogometniKlub
    {
        public abstract void DetaljiKomponente();
        public abstract INogometniKlub KomponentaPostoji(string id);
    }
}