using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IToken
    {
        void PushOrCalculate(Stack<decimal> stack);
    }
}
