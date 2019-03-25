using Lepecki.Playground.Camlc.Engine.Abstractions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.Camlc.Engine
{
    public class ExprSieve : IExprSieve
    {
        private static readonly Regex TokenRegex = new Regex(Patterns.AnyToken, RegexOptions.IgnoreCase);

        public IReadOnlyCollection<string> Sieve(string expr)
        {
            Match match = TokenRegex.Match(expr);
            return IdentifySymbols(match).ToArray();
        }

        private IEnumerable<string> IdentifySymbols(Match match)
        {
            while (match.Success)
            {
                string exprComponent = match.Value.Trim().ToUpperInvariant();
                match = match.NextMatch();
                yield return exprComponent;
            }
        }
    }
}
