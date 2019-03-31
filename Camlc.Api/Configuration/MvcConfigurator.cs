using Lepecki.Playground.Camlc.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lepecki.Playground.Camlc.Api.Configuration
{
    public class MvcConfigurator
    {
        public Action<MvcOptions> GetMvcConfiguratior()
        {
            return options =>  options.Filters.Add(typeof(TaskCanceledExceptionFilter));
        }
    }
}
