using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Memento
{
    public interface IMemento
    {
        int GetRaspored();
        bool StanjeVazeci();
        DateTime GetDatum();
        List<Utakmica> GetUtakmice();
        void MakniVazeci();
        void PostaviVazeci();
    }
}
