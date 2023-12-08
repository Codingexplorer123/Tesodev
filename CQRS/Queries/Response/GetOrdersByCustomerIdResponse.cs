namespace TesodevCase.CQRS.Queries.Response
{
    public class GetOrdersByCustomerIdResponse
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
    }
}
