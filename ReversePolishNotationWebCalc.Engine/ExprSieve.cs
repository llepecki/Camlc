using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class ExprSieve : IExprSieve
    {
        private static readonly Regex _tokenRegex = new Regex(@"\s*(add|sub|mul|div|pow|min|max|neg|\d+(.\d+)?|\(|\))\s*", RegexOptions.IgnoreCase);

        public IReadOnlyCollection<string> Sieve(string expr)
        {
            Match match = _tokenRegex.Match(expr);
            return IdentifyExprComponents(match).ToArray();
        }

        private IEnumerable<string> IdentifyExprComponents(Match match)
        {
            while (match.Success)
            {
                string exprComponent = match.Value.Trim().ToLower();
                match = match.NextMatch();
                yield return exprComponent;
            }
        }
    }
}
