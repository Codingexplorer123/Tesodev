using System.Runtime.CompilerServices;
using TesodevCase.CQRS.Handlers.CommandHandlers;

namespace TesodevCase.Service
{
    public static class TesodevServices
    {
        public static IServiceCollection AddTesodevServices (this IServiceCollection services)
        {
            services.AddScoped<CreateCustomerCommandHandler> ();



            return services;
        }
    }
}
