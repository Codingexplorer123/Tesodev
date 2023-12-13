using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {

        [Required(ErrorMessage ="CustomerId girilmesi zorunludur.")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Miktar girilmesi zorunludur.")]
        [Range(1, 1000, ErrorMessage ="Miktar 0 dan buyu en fazla 1000 adet girilebilir")]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Fiyat girilmek zorundadir")]
        [Range(1,30000,ErrorMessage ="Fiyat 1 ile 30bin arasinda bir sayi olmalidir.")]
        public double Price { get; set; }
        public string Status { get; set; }

        [FromBody]
        public Address Address { get; set; }
        [FromBody]
        public Product Product { get; set; }
       

    }

}
