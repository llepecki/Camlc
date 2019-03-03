using System;

namespace ReversePolishNotationWebCalc.Engine
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);
    }
}