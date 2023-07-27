using Microsoft.AspNetCore.Mvc;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Models;

namespace Micro.OrderManagementService.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderLineController : ControllerBase
	{
		private readonly IOrderLineService _orderLineService;

		public OrderLineController(IOrderLineService orderLineService)
		{
			_orderLineService = orderLineService;
		}

		[HttpGet]
		public IActionResult GetOrderLines()
		{
			var orderLines = _orderLineService.ReadOrderLines();
			return Ok(orderLines);
		}

		[HttpGet("{id}")]
		public IActionResult GetOrderLineById(string id)
		{
			var orderLine = _orderLineService.ReadOrderLineById(id);
			if (orderLine == null)
			{
				return NotFound();
			}
			return Ok(orderLine);
		}

		[HttpPost]
		public IActionResult CreateOrderLine(OrderLine orderLine)
		{
			var result = _orderLineService.SaveOrderLine(orderLine);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateOrderLine(string id, OrderLine orderLine)
		{
			var existingOrderLine = _orderLineService.ReadOrderLineById(id);
			if (existingOrderLine == null)
			{
				return NotFound();
			}
			orderLine.Id = id;
			var result = _orderLineService.UpdateOrderLine(orderLine);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteOrderLine(string id)
		{
			var result = _orderLineService.DeleteOrderLine(id);
			return Ok(result);
		}
	}
}
