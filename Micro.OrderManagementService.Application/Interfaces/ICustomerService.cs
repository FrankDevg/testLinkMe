using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Domain.Models.Customer> ReadCustomers();
        int SaveCustomer(Domain.Models.Customer customer);
        int UpdateCustomer(Domain.Models.Customer customer);
        int DeleteCustomer(string id);
        Domain.Models.Customer ReadCustomerById(string id);
    }
}
