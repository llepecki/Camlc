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
            IEnumerable<TokenDescriptor> descriptors = symbols.Select(_tokenDescriptorFactory.Create);
            IList<TokenDescriptor> output = new List<TokenDescriptor>();
            var stack = new Stack<TokenDescriptor>();

            foreach (TokenDescriptor descriptor in descriptors)
            {
                Advance(descriptor, stack, output);
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return output.ToArray();
        }

        private static void Advance(TokenDescriptor descriptor, Stack<TokenDescriptor> stack, IList<TokenDescriptor> output)
        {
            if (descriptor.IsOperand)
            {
                output.Add(descriptor);
            }
            else if (descriptor.IsOperator)
            {
                if (stack.Count == 0 || stack.Peek().IsLeftParenthesis)
                {
                    stack.Push(descriptor);
                }
                else if (descriptor.Precedence > stack.Peek().Precedence)
                {
                    stack.Push(descriptor);
                }
                else if (descriptor.Precedence == stack.Peek().Precedence)
                {
                    output.Add(stack.Pop());
                    stack.Push(descriptor);
                }
                else if (descriptor.Precedence < stack.Peek().Precedence)
                {
                    output.Add(stack.Pop());
                    Advance(descriptor, stack, output);
                }
            }
            else if (descriptor.IsLeftParenthesis)
            {
                stack.Push(descriptor);
            }
            else if (descriptor.IsRightParenthesis)
            {
                descriptor = stack.Pop();

                while (!descriptor.IsLeftParenthesis)
                {
                    output.Add(descriptor);
                    descriptor = stack.Pop();
                }
            }
        }
    }
}
