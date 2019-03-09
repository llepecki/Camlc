namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Tokens
{
    public class SubtractOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return a - b;
        }
    }
}
