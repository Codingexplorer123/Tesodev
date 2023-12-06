using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Address Address { get; set; }
    }
}
