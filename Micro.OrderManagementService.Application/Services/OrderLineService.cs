using System;
using System.Collections.Generic;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Domain.Interfaces;
namespace Micro.OrderManagementService.Application.Services
{
	public class OrderLineService : IOrderLineService
	{
		private readonly IOrderLineRepository _orderLineRepository; 

		public OrderLineService(IOrderLineRepository orderLineRepository)
		{
			_orderLineRepository = orderLineRepository;
		}

		public IEnumerable<OrderLine> ReadOrderLines()
		{
			return _orderLineRepository.ReadOrderLines();
		}

		public OrderLine ReadOrderLineById(string id)
		{
			return _orderLineRepository.ReadOrderLineById(id);
		}

		public int SaveOrderLine(OrderLine orderLine)
		{
			return _orderLineRepository.SaveOrderLine(orderLine);
		}

		public int UpdateOrderLine(OrderLine orderLine)
		{
			return _orderLineRepository.UpdateOrderLine(orderLine);
		}

		public int DeleteOrderLine(string id)
		{
			return _orderLineRepository.DeleteOrderLine(id);
		}

		public IEnumerable<OrderLine> ReadOrderLinesByOrderId(string orderId)
		{
			return _orderLineRepository.ReadOrderLinesByOrderId(orderId);
		}
	}
}
