using api_doc_mongodb.application.Services;
using api_doc_mongodb.domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_mongodb.ioc.Registers
{
    public static class IoCExtensionServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services
                .AddSingleton<ICustomerService, CustomerService>();
        }
    }
}