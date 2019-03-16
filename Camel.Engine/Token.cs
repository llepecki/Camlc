using System.Collections.Generic;

namespace Lepecki.Playground.Camel.Engine
{
    public abstract class Token
    {
        public abstract void PushOrCalculate(Stack<double> stack);
    }
}
