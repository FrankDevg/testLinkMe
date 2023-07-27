using System.Collections.Generic;
using Micro.OrderManagementService.Domain.Models;


namespace MicroBroker.OrderManagementService.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadCustomers();
        void AddCustomer(Customer customer);
        int SaveCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(string id);
        Customer ReadCustomerById(string id);
    }
}
