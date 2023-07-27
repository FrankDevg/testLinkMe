using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Infraestructure.Context;
using MicroBroker.OrderManagementService.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Infraestructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GlobalDbContext _dbContext;

        public CustomerRepository(GlobalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return _dbContext.Customers.Find(_ => true).ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.InsertOne(customer);
        }

        public int SaveCustomer(Customer customer)
        {
           
                _dbContext.Customers.InsertOne(customer);
           
           
            return 0;
        }

        public int UpdateCustomer(Customer customer)
        {
            var result = _dbContext.Customers.ReplaceOne(c => c._id == customer._id, customer);
            return (int)result.ModifiedCount;
        }

        public int DeleteCustomer(string id)
        {
            var result = _dbContext.Customers.DeleteOne(c => c._id == id);
            return (int)result.DeletedCount;
        }

        public Customer ReadCustomerById(string id)
        {
            return _dbContext.Customers.Find(c => c._id == id).FirstOrDefault();
        }
    }
}
