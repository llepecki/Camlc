using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public interface IToken
    {
        void PushOrCalculate(Stack<decimal> stack);
    }
}
