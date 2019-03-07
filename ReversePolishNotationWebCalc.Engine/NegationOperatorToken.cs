namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class NegationOperatorToken : UnaryOperatorToken
    {
        protected override double Calculate(double a)
        {
            return -a;
        }
    }
}