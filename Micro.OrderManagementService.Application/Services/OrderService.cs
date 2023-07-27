using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micro.OrderManagementService.Application.Interfaces;

using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Domain.Interfaces;

namespace Micro.OrderManagementService.Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public IEnumerable<Domain.Models.Order> ReadOrders()
		{
			return _orderRepository.ReadOrders();
		}

		public Order ReadOrderById(string id)
		{
			return _orderRepository.ReadOrderById(id);
		}
		public int SaveOrder(Domain.Models.Order order)
		{
			return _orderRepository.SaveOrder(order);
		}

		public int UpdateOrder(Domain.Models.Order order)
		{
			return _orderRepository.UpdateOrder(order);
		}

		public int DeleteOrder(string id)
		{
			return _orderRepository.DeleteOrder(id);
		}

		public IEnumerable<Domain.Models.Order> ReadOrdersByCustomerId(string customerId)
		{
			return _orderRepository.ReadOrdersByCustomerId(customerId);
		}
	}
}
