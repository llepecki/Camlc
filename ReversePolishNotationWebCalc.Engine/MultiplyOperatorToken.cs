namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class MultiplyOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return a * b;
        }
    }
}
