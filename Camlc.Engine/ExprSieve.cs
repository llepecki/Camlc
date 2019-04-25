using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Com.Lepecki.Playground.Camlc.Engine
{
    public class ExprSieve : IExprSieve
    {
        private static readonly Regex AnyToken = new Regex(@"(ADD|SUB|MUL|DIV|POW|MIN|MAX|NEG|\d+(.\d+)?|\(|\))", RegexOptions.Singleline);

        public IReadOnlyCollection<string> Sieve(string expr)
        {
            MatchCollection matches = AnyToken.Matches(expr);
            var symbols = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                symbols[i] = matches[i].Value;
            }

            return symbols;
        }

        public Task<IReadOnlyCollection<string>> SieveAsync(string expr, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(Sieve(expr));
        }
    }
}
