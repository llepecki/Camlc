namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class SubtractOperatorToken : BinaryOperatorToken
    {
        protected override decimal Calculate(decimal a, decimal b)
        {
            return a - b;
        }
    }
}
