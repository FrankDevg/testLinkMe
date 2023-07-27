using System;
using System.Collections.Generic;
using Micro.OrderManagementService.Domain.Models;

namespace Micro.OrderManagementService.Domain.Interfaces
{
	public interface IOrderLineRepository
	{
		IEnumerable<OrderLine> ReadOrderLines();
		OrderLine ReadOrderLineById(string id); 
		void AddOrderLine(OrderLine orderLine);
		int SaveOrderLine(OrderLine orderLine);
		int UpdateOrderLine(OrderLine orderLine);
		int DeleteOrderLine(string id);
		IEnumerable<OrderLine> ReadOrderLinesByOrderId(string orderId);
	}
}
