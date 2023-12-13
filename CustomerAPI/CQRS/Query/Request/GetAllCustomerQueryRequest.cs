using MediatR;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Request
{
    public class GetAllCustomerQueryRequest: IRequest<List<Customer>>
    {

    }
}
