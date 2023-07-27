using Micro.OrderManagementService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Domain.Interfaces
{
	public interface IOrderRepository
	{
		IEnumerable<Order> ReadOrders();
		void AddOrder(Order order);
		int SaveOrder(Order order);
		int UpdateOrder(Order order);
		int DeleteOrder(string id);
		Order ReadOrderById(string id);
		IEnumerable<Order> ReadOrdersByCustomerId(string customerId);
	}
}
