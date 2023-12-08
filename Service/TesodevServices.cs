using System.Runtime.CompilerServices;
using TesodevCase.CQRS.Handlers.CommandHandlers;
using TesodevCase.CQRS.Handlers.QueryHandlers;

namespace TesodevCase.Service
{
    public static class TesodevServices
    {
        public static IServiceCollection AddTesodevServices (this IServiceCollection services)
        {
            services.AddScoped<CreateCustomerCommandHandler> ();
            services.AddScoped<CreateOrderCommandHandler> ();
            services.AddScoped<DeleteCustomerCommandHandler> ();
            services.AddScoped<DeleteOrderCommandHandler> ();
            services.AddScoped<UpdateCustomerCommandHandler> ();
            services.AddScoped<UpdateOrderCommandHandler> ();

            services.AddScoped<GetAllCustomerQueryHandler> ();
            services.AddScoped<GetAllOrderQueryHandler> ();
            services.AddScoped<GetCustomerByIdQueryHandler> ();
            services.AddScoped<GetOrderByIdQueryHandler> ();
            services.AddScoped<GetOrdersByCustomerIdQueryHandler> ();
            services.AddScoped<ValidateCustomerByIdQueryHandler> ();




            return services;
        }
    }
}
