using api_doc_mongodb.infraestructure.Entities;
using api_doc_mongodb.ioc.Registers;
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
                c.AddPolicy("AllowOrigin", options => options.AllowAnyMethod().AllowAnyHeader());
            });

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API DOC MONGODB", Version = "v1" });
            });

            Services.AddEndpointsApiExplorer();

            Services.AddAuthorization();

            return Services;
        }
    }
}
