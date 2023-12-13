using MediatR;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class UpdateCustomerCommandRequest: IRequest<UpdateCustomerCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime UpdatedAt { get; set; }

        
    }
}
