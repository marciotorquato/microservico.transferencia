using Microservico.Transferencia.Domain;
using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Repository.Repository;
using Microservico.Transferencia.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microservico.Transferencia.Api.Config
{
    public static class DependencyInjectionConfig
    {

        /// <summary>
        /// Responsavel por registrar as injeções de depêndencias
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            // Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();            

            // Services
            services.AddScoped<ILancamentoService, LancamentoService>();

            // Repository
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            return services;
        }
    }
}