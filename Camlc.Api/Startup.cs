using Lepecki.Playground.Camlc.Api.Configuration;
using Lepecki.Playground.Camlc.Engine.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lepecki.Playground.Camlc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting(StartupOptions.Routing.SetupRouting);
            services.AddApiVersioning(StartupOptions.ApiVersioning.SetupApiVersioning);
            services.AddSwaggerGen(StartupOptions.Swagger.SetupSwaggerGen);
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
            app.UseSwaggerUI(StartupOptions.Swagger.GetSwaggerUiConfigurator(env));
        }
    }
}
