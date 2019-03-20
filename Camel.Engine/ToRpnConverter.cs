using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine
{
    public class ToRpnConverter : IToRpnConverter
    {
        private readonly IExprSieve _exprSieve;
        private readonly IInfixToPostfixConverter _infixToPostfixConverter;
        private readonly ITokenizer _tokenizer;

        public ToRpnConverter(
            IExprSieve exprSieve,
            IInfixToPostfixConverter infixToPostfixConverter,
            ITokenizer tokenizer)
        {
            _exprSieve = exprSieve ?? throw new ArgumentNullException(nameof(exprSieve));
            _infixToPostfixConverter = infixToPostfixConverter ?? throw new ArgumentNullException(nameof(infixToPostfixConverter));
            _tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
        }

        public RpnExpr Convert(string expr)
        {
            IReadOnlyCollection<string> infixExpr = _exprSieve.Sieve(expr);
            IReadOnlyCollection<TokenDescriptor> postfixExpr = _infixToPostfixConverter.Convert(infixExpr);
            IEnumerable<Token> tokens = postfixExpr.Select(_tokenizer.Create);
            return new RpnExpr(tokens);
        }
    }
}
