using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        [FromBody]
        public Address Address { get; set; }
    }
}
