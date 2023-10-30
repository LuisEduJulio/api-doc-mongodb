using api_doc_mongodb.infraestructure.Entities;
using api_doc_mongodb.ioc.Registers;
using api_doc_mongodb.utility.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace api_doc_mongodb.ioc.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterIocDependencies(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services
               .AddMvc();

            Services
               .AddHttpClient();

            Services
                .AddControllers();

            Services
                .AddLogging();

            Services
                .Configure<AppSettings>(Configuration);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var appSettings = configuration.Get<AppSettings>();

            Services
             .RegisterAutoMappers();

            Services
                .RegisterRepositories();

            Services
                .RegisterServices();

            Services.AddCors(c =>
            {
                c.AddPolicy(EnvironmentHelper.GetCross(),
                    options => options
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(EnvironmentHelper.GetVersionApi(),
                    new OpenApiInfo
                    {
                        Title = EnvironmentHelper.GetApplicationName(),
                        Version = EnvironmentHelper.GetVersionApi()
                    });
            });

            Services.AddEndpointsApiExplorer();

            Services.AddAuthorization();

            return Services;
        }
    }
}
