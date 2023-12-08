using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        [FromBody]
        public Address Address { get; set; }
        [FromBody]
        public Product Product { get; set; }
       

    }

}
