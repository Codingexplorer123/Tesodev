using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.Entities;

namespace TesodevCase.CQRS.Commands.Request
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        [Required(ErrorMessage = "isim girilmesi zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage =" Email girilmesi zorunludur")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Gecersiz bir email adresi girildi")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Address Address { get; set; }
    }
}
