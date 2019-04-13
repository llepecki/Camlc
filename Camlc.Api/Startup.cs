using System;
using Com.Lepecki.Playground.Camlc.Api.Configuration;
using Com.Lepecki.Playground.Camlc.Engine.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Com.Lepecki.Playground.Camlc.Api
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
            services.AddMvc(_startupOptions.Configure).SetCompatibilityVersion(CompatibilityVersion.Version_2_2); // TODO: consider AddMvcCore
            services.AddRouting(_startupOptions.Configure);
            services.AddApiVersioning(_startupOptions.Configure);
            services.AddVersionedApiExplorer(_startupOptions.Configure);
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>(); // TODO: maybe don't create configure method but use IConfigureOptions<> ?
            services.AddSwaggerGen(); // TODO: missing options
            services.AddMemoryCache();
            services.AddEngine();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options => _startupOptions.Configure(options, provider));
        }
    }
}
