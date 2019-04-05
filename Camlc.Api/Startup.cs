using Lepecki.Playground.Camlc.Api.Configuration;
using Lepecki.Playground.Camlc.Engine.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lepecki.Playground.Camlc.Api
{
    public class Startup
    {
        private readonly IStartupOptions _startupOptions;
        private readonly IConfiguration _configuration;

        public Startup(IStartupOptions startupOptions, IConfiguration configuration)
        {
            _startupOptions = startupOptions ?? throw new ArgumentNullException(nameof(startupOptions));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(_startupOptions.Configure).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting(_startupOptions.Configure);
            services.AddApiVersioning(_startupOptions.Configure);
            services.AddSwaggerGen(_startupOptions.Configure);
            services.AddMemoryCache();
            services.AddEngine();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(_startupOptions.Configure);
        }
    }
}
