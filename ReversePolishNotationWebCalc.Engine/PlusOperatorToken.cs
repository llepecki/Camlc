namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class PlusOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return a + b;
        }
    }
}