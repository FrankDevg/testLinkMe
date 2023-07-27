using Microsoft.AspNetCore.Mvc;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Models;

namespace Micro.OrderManagementService.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			var products = _productService.ReadProducts();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public IActionResult GetProductById(string id)
		{
			var product = _productService.ReadProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public IActionResult CreateProduct(Product product)
		{
			var result = _productService.SaveProduct(product);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateProduct(string id, Product product)
		{
			var existingProduct = _productService.ReadProductById(id);
			if (existingProduct == null)
			{
				return NotFound();
			}
			product._id = id;
			var result = _productService.UpdateProduct(product);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(string id)
		{
			var result = _productService.DeleteProduct(id);
			return Ok(result);
		}
	}
}
