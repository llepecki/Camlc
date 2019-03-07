using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Module
{
    public static class EngineModule
    {
        public static void AddEngine(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICalc, FakeCalc>();
        }
    }
}
