using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesodevCase.Entities;

namespace TesodevCase.Entities
{
    public class Customer 
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public DateTime CreatedAt { get; set; }
       
        public DateTime UpdatedAt { get; set;}

        public Guid AddressId { get; set; }

        public Address Address { get; set; }
        public Order CustomerId { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }
}
