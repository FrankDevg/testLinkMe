using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Domain.Models.Product> ReadProducts();
        int SaveProduct(Domain.Models.Product product);
        int UpdateProduct(Domain.Models.Product product);
        int DeleteProduct(string id);
        Domain.Models.Product ReadProductById(string id);
    }
}
