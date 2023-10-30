using api_doc_mongodb.domain.Repositories;
using api_doc_mongodb.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace api_doc_mongodb.ioc.Registers
{
    public static class IoCExtensionRepositories
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<ICustomerRepository, CustomerRepository>()
                .AddSingleton<IEmailSenderRepository, EmailSenderRepository>();
        }
    }
}
