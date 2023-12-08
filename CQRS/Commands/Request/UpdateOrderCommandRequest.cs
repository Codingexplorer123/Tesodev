using MediatR;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        // Address properties
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        // product properties
        public string ProductImageUrl { get; set; }
        public string ProductName { get; set; }
    }
}
