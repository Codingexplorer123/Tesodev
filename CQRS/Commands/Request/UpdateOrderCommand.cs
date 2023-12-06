using MediatR;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductName { get; set; }
    }
}
