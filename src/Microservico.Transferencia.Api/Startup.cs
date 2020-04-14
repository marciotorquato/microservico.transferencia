using Microservico.Transferencia.Api.Config;
using Microservico.Transferencia.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservico.Transferencia.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();            

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransferenciaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TransferenciaConnectionString"));
            });

            // Responsavel por registrar as configurações registradas na classe "ApiConfig"
            services.WebApiConfig();

            // Responsavel por registrar todas as injeções de dependencia registradas na classe "DependencyInjectionConfig"
            services.ResolveDependency();

            // Responsavel por registrar as configurações do swagger
            services.AddSwaggerConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseMvcConfiguration();
            app.UseSwaggerConfig(provider);
        }
    }
}