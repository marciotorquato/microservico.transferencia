using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Microservico.Transferencia.Api.Config
{
    public static class ApiConfig
    {

        /// <summary>
        /// Responsavel por configurar o versionamento da aplicação para o Swagger
        /// Responsavel por adicionar configuração de CORs
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            //Configuração de CORS
            services.AddCors(options =>
            {

                //Politica de desenvolvimento permite qualquer requisição
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

                //Politica para Produção
                options.AddPolicy("Production",
                    builder =>
                        builder
                        .WithMethods("GET", "POST") //só vai permitir requisições do tipo GET
                        .WithOrigins("https://SITE_PERMITIDO_1.com.br", "https://SITE_PERMITIDO_2.com.br") //só permite acessos com a origem SITE_PERMITIDO.com.br
                        .SetIsOriginAllowedToAllowWildcardSubdomains() //permite acesso a subdominios do site Origin
                        .WithHeaders(HeaderNames.ContentType, "x-custom-header")); //tipo de header
            });

            return services;
        }

        /// <summary>
        /// Responsavel por adicionar configurações de uso do Mvc
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }
    }
}