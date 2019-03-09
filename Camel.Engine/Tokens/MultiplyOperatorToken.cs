namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class MultiplyOperatorToken : BinaryOperatorToken
    {
        protected override double Calculate(double a, double b)
        {
            return a * b;
        }
    }
}
