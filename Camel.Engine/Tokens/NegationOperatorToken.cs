namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class NegationOperatorToken : UnaryOperatorToken
    {
        protected override double Calculate(double a)
        {
            return -a;
        }
    }
}