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
    public class OrderRepository : IOrderRepository
    {
        private readonly GlobalDbContext _dbContext;

        public OrderRepository(GlobalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _dbContext.Orders.Find(_ => true).ToList();
        }
        public Order ReadOrderById(string id)
        {
            return _dbContext.Orders.Find(o => o.Id == id).FirstOrDefault();
        }
        public void AddOrder(Order order)
        {
            _dbContext.Orders.InsertOne(order);
        }

        public int SaveOrder(Order order)
        {
           
                _dbContext.Orders.InsertOne(order);
            
            return 0;
        }

        public int UpdateOrder(Order order)
        {
            var result = _dbContext.Orders.ReplaceOne(o => o.Id == order.Id, order);
            return (int)result.ModifiedCount;
        }

        public int DeleteOrder(string id)
        {
            var result = _dbContext.Orders.DeleteOne(o => o.Id == id);
            return (int)result.DeletedCount;
        }

        public IEnumerable<Order> ReadOrdersByCustomerId(string customerId)
        {
            return _dbContext.Orders.Find(o => o.CustomerId == customerId).ToList();
        }
    }
}
