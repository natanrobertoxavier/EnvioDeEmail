using EnvioDeEmail.Domain.Repository;
using EnvioDeEmail.Infrastructure.AccessRepository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnvioDeEmail.Infrastructure;
public static class Initializer
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IMailOnlySender, MailSender>();
    }
}
