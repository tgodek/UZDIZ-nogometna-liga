using System;
using System.Collections.Generic;
using System.Text;
using tgodek_zadaca_1.Composite;

namespace tgodek_zadaca_1.Visitor
{
    public interface IOperation
    {
        void Visit(Klub klub);
        void Visit(Igrac igrac);
        void Visit(Trener trener);
        void Visit(Utakmica utakmica);
        void Visit(SastavUtakmice sastav);
        void Visit(Dogadaj dogadaj);
    }

    public abstract class Get<T> : IOperation
    {
        public T Result { get; set; }
        public abstract void Visit(Dogadaj dogadaj);
        public abstract void Visit(Igrac igrac);
        public abstract void Visit(Klub klub);
        public abstract void Visit(SastavUtakmice sastav);
        public abstract void Visit(Trener trener);
        public abstract void Visit(Utakmica utakmica);
    }

}
