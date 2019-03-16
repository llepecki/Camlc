using Lepecki.Playground.Camel.Engine.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lepecki.Playground.Camel.Api
{
    public class Startup
    {
        private readonly SwaggerConfigurator _swaggerConfigurator;

        public Startup()
        {
            _swaggerConfigurator = new SwaggerConfigurator
            {
                Name = "Camel API",
                Version = "v1",
                Description = "Web calculator poweredy by Reverse Polish Notation"
            };
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(_swaggerConfigurator.SetupGenOptions);
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
            app.UseSwaggerUI(_swaggerConfigurator.SetupUiOptions);
        }
    }
}
