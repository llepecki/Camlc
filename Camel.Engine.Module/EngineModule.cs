using Lepecki.Playground.Camel.Engine.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Lepecki.Playground.Camel.Engine.Module
{
    public static class EngineModule
    {
        public static void AddEngine(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICalc, YouBastardCalc>();
            serviceCollection.AddTransient<IToRpnConverter, ToRpnConverter>();
            serviceCollection.AddTransient<IExprSieve, ExprSieve>();
            serviceCollection.AddTransient<IInfixToPostfixConverter, InfixToPostfixConverter>();
            serviceCollection.AddTransient<ITokenizer, Tokenizer>();
            serviceCollection.AddTransient<ITokenDescriptorFactory, TokenDescriptorFactory>();
        }
    }
}
