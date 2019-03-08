namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public static class Patterns
    {
        public const string Decimal = @"^\d+(.\d+)?$";

        public const string AnyToken = @"\s*(add|sub|mul|div|pow|min|max|neg|\d+(.\d+)?|\(|\))\s*";
    }
}