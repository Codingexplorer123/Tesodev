namespace TesodevCase.CQRS.Queries.Response
{
    public class GetOrderByIdQueryResponse
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
