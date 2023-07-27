using Micro.OrderManagementService.Domain.Interfaces;
using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Infraestructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Infraestructure.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly GlobalDbContext _dbContext;

        public OrderLineRepository(GlobalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderLine> ReadOrderLines()
        {
            return _dbContext.OrderLines.Find(_ => true).ToList();
        }
        public OrderLine ReadOrderLineById(string id)
        {
            return _dbContext.OrderLines.Find(ol => ol.Id == id).FirstOrDefault();
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            _dbContext.OrderLines.InsertOne(orderLine);
        }

        public int SaveOrderLine(OrderLine orderLine)
        {
            
                _dbContext.OrderLines.InsertOne(orderLine);
            
           
      
            return 0;
        }

        public int UpdateOrderLine(OrderLine orderLine)
        {
            var result = _dbContext.OrderLines.ReplaceOne(ol => ol.Id == orderLine.Id, orderLine);
            return (int)result.ModifiedCount;
        }

        public int DeleteOrderLine(string id)
        {
            var result = _dbContext.OrderLines.DeleteOne(ol => ol.Id == id);
            return (int)result.DeletedCount;
        }

        public IEnumerable<OrderLine> ReadOrderLinesByOrderId(string orderId)
        {
            return _dbContext.OrderLines.Find(ol => ol.OrderId == orderId).ToList();
        }
    }
}
