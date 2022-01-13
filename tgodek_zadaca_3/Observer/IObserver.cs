using System;
using System.Collections.Generic;
using System.Text;

namespace tgodek_zadaca_3.Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
