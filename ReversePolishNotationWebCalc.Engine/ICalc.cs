using System;

namespace ReversePolishNotationWebCalc.Engine
{
    public interface ICalc
    {
        double Calculate(string expr);
    }
}
