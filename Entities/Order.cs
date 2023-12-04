﻿using System.Net.Http.Headers;

namespace TesodevCase.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public string Status { get; set; }

        public Address Address { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Customer Customer { get; set; }

    }
}
