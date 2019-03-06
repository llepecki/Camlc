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