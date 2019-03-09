namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Tokens
{
    public class NegationOperatorToken : UnaryOperatorToken
    {
        protected override double Calculate(double a)
        {
            return -a;
        }
    }
}