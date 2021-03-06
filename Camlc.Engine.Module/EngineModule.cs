﻿using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Lepecki.Playground.Camlc.Engine.Module
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
