using Micro.OrderManagementService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.OrderManagementService.Domain.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> ReadProducts();
		Product ReadProductById(string id);
		void AddProduct(Product product);
		int SaveProduct(Product product);
		int UpdateProduct(Product product);
		int DeleteProduct(string id);
	}
}
