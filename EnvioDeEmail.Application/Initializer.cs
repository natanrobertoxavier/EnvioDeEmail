using EnvioDeEmail.Application.UseCases.SendMail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnvioDeEmail.Application;
public static class Initializer
{
    public static void AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddUseCase(services);
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<ISendMailUseCase, SendMailUseCase>();
    }
}
