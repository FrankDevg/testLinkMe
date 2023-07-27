using Microsoft.AspNetCore.Mvc;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Models;

namespace Micro.OrderManagementService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.ReadOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(string id)
        {
            var order = _orderService.ReadOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            var result = _orderService.SaveOrder(order);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(string id, Order order)
        {
            var existingOrder = _orderService.ReadOrderById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            order.Id = id;
            var result = _orderService.UpdateOrder(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(string id)
        {
            var result = _orderService.DeleteOrder(id);
            return Ok(result);
        }
    }
}
