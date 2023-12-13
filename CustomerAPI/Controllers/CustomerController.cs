using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.Entities;

namespace TesodevCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([FromQuery] GetAllCustomerQueryRequest request)
        {
            List<Customer> customers = await _mediator.Send(request);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCustomer([FromQuery] GetCustomerByIdQueryRequest request)
        {
            GetCustomerByIdQueryResponse customer = await _mediator.Send(request);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandRequest request)
        {
            CreateCustomerCommandResponse customer = await _mediator.Send(request);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommandRequest request)
        {
            UpdateCustomerCommandResponse customer = await _mediator.Send(request);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommandRequest request)
        {
           DeleteCustomerCommandResponse customer = await _mediator.Send(request);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        public async Task<IActionResult> ValidateCustomer([FromBody] ValidateCustomerByIdQuery request)
        {
            ValidateCustomerByIdResponse response = await _mediator.Send(request);
            if(response.IsAvailable)
            {
                return Ok(new { Message = "Musteri var" });
            }
            return BadRequest(new { Message = " Girilen Id 'de musteri bulunmamaktadir."});

        }
    }
}
