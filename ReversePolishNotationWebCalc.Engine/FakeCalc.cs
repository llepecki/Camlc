using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class FakeCalc : ICalc
    {
        public double Calculate(string expr)
        {
            return 42;
        }
    }
}
