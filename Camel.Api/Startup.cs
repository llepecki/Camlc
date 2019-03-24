using Lepecki.Playground.Camel.Api.Options;
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
        private readonly RoutingConfigurator _routingConfigurator;
        private readonly SwaggerConfigurator _swaggerConfigurator;

        public Startup(IConfiguration configuration)
        {
            _routingConfigurator = new RoutingConfigurator();
            
            _swaggerConfigurator = new SwaggerConfigurator
            {
                Name = "Camel API",
                Version = "v1",
                Description = "Web calculator powered by Reverse Polish Notation"
            };
            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting(_routingConfigurator.SetupRoutingOptions);
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
