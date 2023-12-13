using System.Runtime.CompilerServices;
using TesodevCase.CQRS.Handlers.CommandHandlers;
using TesodevCase.CQRS.Handlers.QueryHandlers;

namespace TesodevCase.Service
{
    public static class CustomerServices
    {
        public static IServiceCollection AddCustomerServices (this IServiceCollection services)
        {
            services.AddScoped<CreateCustomerCommandHandler> ();
           
            services.AddScoped<DeleteCustomerCommandHandler> ();
           
            services.AddScoped<UpdateCustomerCommandHandler> ();
            

            services.AddScoped<GetAllCustomerQueryHandler> ();
           
            services.AddScoped<GetCustomerByIdQueryHandler> ();
           
            services.AddScoped<GetOrdersByCustomerIdQueryHandler> ();
            services.AddScoped<ValidateCustomerByIdQueryHandler> ();




            return services;
        }
    }
}
