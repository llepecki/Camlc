using System;
using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class ToRpnConverter : IToRpnConverter
    {
        private readonly IExprSieve _exprSieve;
        private readonly IExprTreeFactory _exprTreeFactory;

        public ToRpnConverter(IExprSieve exprSieve, IExprTreeFactory exprTreeFactory)
        {
            _exprSieve = exprSieve ?? throw new ArgumentNullException(nameof(exprSieve));
            _exprTreeFactory = exprTreeFactory ?? throw new ArgumentNullException(nameof(exprTreeFactory));
        }

        public RpnExpr Convert(string expr)
        {
            IEnumerable<string> exprMembers = _exprSieve.Sieve(expr); // shitty name; to a separate class?
            ExprTree exprTree = _exprTreeFactory.Build(exprMembers);
            return new RpnExpr(exprTree.TraverseInOrder());
        }
    }
}
