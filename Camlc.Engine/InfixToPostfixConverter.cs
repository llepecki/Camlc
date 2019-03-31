using Lepecki.Playground.Camlc.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                Process(descriptor, stack, output);
            }

            return Merge(stack, output);
        }

        public Task<IReadOnlyCollection<TokenDescriptor>> ConvertAsync(IEnumerable<string> symbols, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            return Task.FromResult(Convert(symbols));
        }

        private static void Process(TokenDescriptor descriptor, Stack<TokenDescriptor> stack, IList<TokenDescriptor> output)
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
                    Process(descriptor, stack, output);
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

        private static IReadOnlyCollection<TokenDescriptor> Merge(Stack<TokenDescriptor> stack, IList<TokenDescriptor> output)
        {
            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return output.ToArray();
        }
    }
}
