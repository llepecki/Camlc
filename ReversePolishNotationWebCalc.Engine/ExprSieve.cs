using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class ExprSieve : IExprSieve
    {
        private static readonly Regex _tokenRegex = new Regex(@"\s*(add|sub|mul|div|pow|min|max|neg|\d+(.\d+)?|\(|\))\s*");
        
        public IEnumerable<string> Sieve(string expr)
        {
            throw new System.NotImplementedException();
        }
    }
}
