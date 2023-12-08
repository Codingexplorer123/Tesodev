using MediatR;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetOrderByIdQueryRequest: IRequest<GetOrderByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
