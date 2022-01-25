using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_3.Composite;

namespace tgodek_zadaca_3.Strategy
{
    public interface IStrategy
    {
        (List<Klub>, List<Klub>) Generiraj();
    }
}
