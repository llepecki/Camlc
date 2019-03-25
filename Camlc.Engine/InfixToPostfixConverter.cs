using Lepecki.Playground.Camlc.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camlc.Engine
{
    public class InfixToPostfixConverter : IInfixToPostfixConverter
    {
        private readonly ITokenDescriptorFactory _tokenDescriptorFactory;

        public InfixToPostfixConverter(ITokenDescriptorFactory tokenDescriptorFactory)
        {
            _tokenDescriptorFactory = tokenDescriptorFactory ?? throw new ArgumentNullException(nameof(tokenDescriptorFactory));
        }

        public IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> symbols)
        {
            IEnumerable<TokenDescriptor> tokenDescriptors = symbols.Select(_tokenDescriptorFactory.Create);
            IList<TokenDescriptor> tokenDescriptorsInPostfixOrder = new List<TokenDescriptor>();
            var stack = new Stack<TokenDescriptor>();

            foreach (TokenDescriptor tokenDescriptor in tokenDescriptors)
            {
                Process(tokenDescriptor, stack, tokenDescriptorsInPostfixOrder);
            }

            while (stack.Count > 0)
            {
                tokenDescriptorsInPostfixOrder.Add(stack.Pop());
            }

            return tokenDescriptorsInPostfixOrder.ToArray();
        }

        // consider moving this logic to TokenDescriptor and writing unit tests
        private void Process(TokenDescriptor tokenDescriptor, Stack<TokenDescriptor> stack, IList<TokenDescriptor> tokenDescriptorsInPostfixOrder)
        {
            if (tokenDescriptor.IsOperand)
            {
                tokenDescriptorsInPostfixOrder.Add(tokenDescriptor);
            }
            else if (tokenDescriptor.IsOperator)
            {
                if (stack.Count == 0 || stack.Peek().IsLeftParenthesis)
                {
                    stack.Push(tokenDescriptor);
                }
                else if (tokenDescriptor.Precedence > stack.Peek().Precedence)
                {
                    stack.Push(tokenDescriptor);
                }
                else if (tokenDescriptor.Precedence == stack.Peek().Precedence)
                {
                    tokenDescriptorsInPostfixOrder.Add(stack.Pop());
                    stack.Push(tokenDescriptor);
                }
                else if (tokenDescriptor.Precedence < stack.Peek().Precedence)
                {
                    tokenDescriptorsInPostfixOrder.Add(stack.Pop());
                    Process(tokenDescriptor, stack, tokenDescriptorsInPostfixOrder);
                }
            }
            else if (tokenDescriptor.IsLeftParenthesis)
            {
                stack.Push(tokenDescriptor);
            }
            else if (tokenDescriptor.IsRightParenthesis)
            {
                var descriptor = stack.Pop();

                while (!descriptor.IsLeftParenthesis)
                {
                    tokenDescriptorsInPostfixOrder.Add(descriptor);
                    descriptor = stack.Pop();
                }
            }
        }
    }
}
