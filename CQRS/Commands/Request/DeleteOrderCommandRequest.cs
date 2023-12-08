using MediatR;
using TesodevCase.CQRS.Commands.Response;

namespace TesodevCase.CQRS.Commands.Request
{
    public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
