using MediatR;

namespace TesodevCase.CQRS.Queries.Request
{
    public class ChangeOrderStatusQueryRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

    }
}
