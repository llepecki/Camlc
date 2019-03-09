using System;
using System.Collections.Generic;
using System.Linq;
using Lepecki.Playground.Camel.Engine.Abstractions;

namespace Lepecki.Playground.Camel.Engine
{
    public class InfixToPostfixConverter : IInfixToPostfixConverter
    {
        private readonly ITokenDescriptorFactory _tokenDescriptorFactory;

        public InfixToPostfixConverter(ITokenDescriptorFactory tokenDescriptorFactory)
        {
            _tokenDescriptorFactory = tokenDescriptorFactory ?? throw new ArgumentNullException(nameof(tokenDescriptorFactory));
        }

        public IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> operandsAndOperators)
        {
            IEnumerable<TokenDescriptor> tokenDescriptors = operandsAndOperators.Select(_tokenDescriptorFactory.Create);
            IList<TokenDescriptor> tokenDescriptorsInPostfixOrder = new List<TokenDescriptor>();
            var stack = new Stack<TokenDescriptor>();

            foreach (TokenDescriptor tokenDescriptor in tokenDescriptors)
            {
                TakeAction(tokenDescriptor, stack, tokenDescriptorsInPostfixOrder);
            }

            while (stack.Count > 0)
            {
                tokenDescriptorsInPostfixOrder.Add(stack.Pop());
            }

            return tokenDescriptorsInPostfixOrder.ToArray();
        }

        // nasty method, needs some refactoring
        private void TakeAction(TokenDescriptor tokenDescriptor, Stack<TokenDescriptor> stack, IList<TokenDescriptor> tokenDescriptorsInPostfixOrder)
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
                else if (tokenDescriptor.Precedence > stack.Peek().Precedence) // TODO: precedence?
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
                    TakeAction(tokenDescriptor, stack, tokenDescriptorsInPostfixOrder);
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
