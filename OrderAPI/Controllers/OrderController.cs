using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.RabbitMQ;
using TesodevCase.CQRS.Commands.Request;
using TesodevCase.CQRS.Commands.Response;
using TesodevCase.CQRS.Queries.Request;
using TesodevCase.CQRS.Queries.Response;
using TesodevCase.Entities;

namespace TesodevCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messagePublisher;
        public OrderController(IMediator mediator, IMessageProducer messageProducer)
        {
            _mediator= mediator;
            _messagePublisher= messageProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder([FromQuery] GetAllOrderQueryRequest request)
        {
            List<Order> allOrders = await _mediator.Send(request);
            return Ok(allOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQueryRequest request)
        {
            
           GetOrderByIdQueryResponse order = await _mediator.Send(request);
            if (order == null)
            {
                return NotFound("Ilgili idli kayit bulunamadi");
            }
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAllOrder([FromQuery] GetOrdersByCustomerIdQuery request)
        {
          List< GetOrdersByCustomerIdResponse> orders = await _mediator.Send(request);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse order = await _mediator.Send(request);
            _messagePublisher.SendMessage(order); // it will publish the message to RabbitMQ
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommandRequest request)
        {
            DeleteOrderCommandResponse order = await _mediator.Send(request);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateOrder (UpdateOrderCommandRequest request)
        {
            UpdateOrderCommandResponse order = await _mediator.Send(request);
            if( order == null)
            {
                return NotFound() ;
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeOrderStatus([FromBody] ChangeOrderStatusQueryRequest request)
        {
            var query = new ChangeOrderStatusQueryRequest
            {
                Id = request.Id,
                Status = request.Status
            };
            var result = await _mediator.Send(query);

            if (result== true)
            {
                return Ok(new { Message = "Siparis durumu guncellendi." });
            }
            return BadRequest(new { Message = "Hata olustu. Lutfen Id degerini kontrol ediniz" });
        }
    }
}
