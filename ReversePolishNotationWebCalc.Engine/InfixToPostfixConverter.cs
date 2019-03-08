using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class InfixToPostfixConverter : IInfixToPostfixConverter
    {
        private readonly ITokenDescriptorFactory _tokenDescriptorFactory;

        public InfixToPostfixConverter(ITokenDescriptorFactory tokenDescriptorFactory)
        {
            _tokenDescriptorFactory = tokenDescriptorFactory ?? throw new ArgumentNullException(nameof(tokenDescriptorFactory));
        }

        public IReadOnlyCollection<string> Convert(IEnumerable<string> operandsAndOperators)
        {
            IList<string> output = new List<string>();

            IEnumerable<TokenDescriptor> tokenDescriptors = operandsAndOperators.Select(_tokenDescriptorFactory.Create);

            throw new NotImplementedException();
        }
    }
}