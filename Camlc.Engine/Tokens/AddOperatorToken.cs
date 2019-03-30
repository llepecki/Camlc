namespace Lepecki.Playground.Camlc.Engine.Tokens
{
    public class AddOperatorToken : BinaryOperatorToken
    {
        protected override decimal Calculate(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
