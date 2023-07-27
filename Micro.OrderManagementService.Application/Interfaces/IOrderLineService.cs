using Micro.OrderManagementService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Application.Interfaces
{
    public interface IOrderLineService
    {
        IEnumerable<Domain.Models.OrderLine> ReadOrderLines();
        OrderLine ReadOrderLineById(string id);
        int SaveOrderLine(Domain.Models.OrderLine orderLine);
        int UpdateOrderLine(Domain.Models.OrderLine orderLine);
        int DeleteOrderLine(string id);
        IEnumerable<Domain.Models.OrderLine> ReadOrderLinesByOrderId(string orderId);
    }
}
