using TesodevCase.Entities;

namespace TesodevCase.CQRS.Queries.Response
{
    public class GetCustomerByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
