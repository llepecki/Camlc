using Com.Lepecki.Playground.Camlc.Api.Filters;
using Com.Lepecki.Playground.Camlc.Api.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public class MvcOptionsConfigurator : IConfigureOptions<MvcOptions>
    {
        private readonly IHostingEnvironment _environment;

        public MvcOptionsConfigurator(IHostingEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void Configure(MvcOptions options)
        {
            if (!_environment.IsProduction())
            {
                options.Filters.Add(new IncludeEnvironmentHeaderFilter(_environment.EnvironmentName));
            }

            options.Filters.Add(typeof(TaskCanceledExceptionFilter));

            options.OutputFormatters.RemoveType<StringOutputFormatter>();
            options.OutputFormatters.RemoveType<StreamOutputFormatter>();
            options.OutputFormatters.Add(new PlainTextOutputFormatter());
            options.OutputFormatters.Add(new CsvOutputFormatter());
            options.OutputFormatters.Add(new XmlOutputFormatter());
        }
    }
}
