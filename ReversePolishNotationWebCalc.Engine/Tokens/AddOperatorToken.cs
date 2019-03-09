namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Tokens
{
    public class AddOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return a + b;
        }
    }
}
