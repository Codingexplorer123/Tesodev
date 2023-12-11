using System.Runtime.CompilerServices;
using TesodevCase.CQRS.Handlers.CommandHandlers;
using TesodevCase.CQRS.Handlers.QueryHandlers;

namespace TesodevCase.Service
{
    public static class TesodevServices
    {
        public static IServiceCollection AddTesodevServices (this IServiceCollection services)
        {
            
            services.AddScoped<CreateOrderCommandHandler> ();
       
            services.AddScoped<DeleteOrderCommandHandler> ();
           
            services.AddScoped<UpdateOrderCommandHandler> ();

           
            services.AddScoped<GetAllOrderQueryHandler> ();
           
            services.AddScoped<GetOrderByIdQueryHandler> ();
          
            




            return services;
        }
    }
}
