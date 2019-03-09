using System.Collections.Generic;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions
{
    public interface IInfixToPostfixConverter
    {
        IReadOnlyCollection<TokenDescriptor> Convert(IEnumerable<string> operandsAndOperators);
    }
}
