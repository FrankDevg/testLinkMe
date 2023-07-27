using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Interfaces;
using Micro.OrderManagementService.Domain.Models;
using MicroBroker.OrderManagementService.Domain.Interfaces;

namespace Micro.OrderManagementService.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public IEnumerable<Product> ReadProducts()
		{
			return _productRepository.ReadProducts();
		}

		public Product ReadProductById(string id)
		{
			return _productRepository.ReadProductById(id);
		}

		public int SaveProduct(Product product)
		{
			return _productRepository.SaveProduct(product);
		}

		public int UpdateProduct(Product product)
		{
			return _productRepository.UpdateProduct(product);
		}

		public int DeleteProduct(string id)
		{
			return _productRepository.DeleteProduct(id);
		}
	}
}
