using System.ComponentModel.DataAnnotations;
using TesodevCase.Entities;

namespace TesodevCase.Entities
{
    public class Customer 
    {
        // Buradaki entitilerin configurasyonunda data annotation ile yaptim. Diger child classi(Address) fluent Api ile yapacagim.
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set;}
        [Required]
        public Address Address { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }
}
