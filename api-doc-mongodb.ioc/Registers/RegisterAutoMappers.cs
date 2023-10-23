using api_doc_mongodb.infraestructure.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_mongodb.ioc.Registers
{
    public static class IoCExtensionAutoMappers
    {
        public static void RegisterAutoMappers(this IServiceCollection services)
        {
            services
                 .AddAutoMapper(typeof(MapperCustomerProfile));
        }
    }
}
