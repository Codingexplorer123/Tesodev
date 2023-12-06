using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class UpdateCustomerCommand: IRequest
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order Order { get; set; }
    }
}
