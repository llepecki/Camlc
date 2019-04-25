using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Com.Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class Token
    {
        public abstract void PushOrCalculate(Stack<decimal> stack);

        public Task PushOrCalculateAsync(Stack<decimal> stack, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            PushOrCalculate(stack);

            return Task.CompletedTask;
        }
    }
}
