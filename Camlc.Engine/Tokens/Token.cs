using System.Collections.Generic;

namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class Token
    {
        public abstract void PushOrCalculate(Stack<decimal> stack);
    }
}