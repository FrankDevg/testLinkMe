using Micro.OrderManagementService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Application.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Domain.Models.Order> ReadOrders();
        Order ReadOrderById(string id);
        int SaveOrder(Domain.Models.Order order);
        int UpdateOrder(Domain.Models.Order order);
        int DeleteOrder(string id);
        IEnumerable<Domain.Models.Order> ReadOrdersByCustomerId(string customerId);
    }
}
