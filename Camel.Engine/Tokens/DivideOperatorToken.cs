namespace Lepecki.Playground.Camel.Engine.Tokens
{
    public class DivideOperatorToken : BinaryOperatorToken
    {
        protected override decimal Calculate(decimal a, decimal b)
        {
            return a / b;
        }
    }
}
