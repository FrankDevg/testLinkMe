using Microsoft.AspNetCore.Mvc;
using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Domain.Models;
using System;

namespace Micro.OrderManagementService.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public IActionResult GetCustomers()
		{
			try
			{
				var customers = _customerService.ReadCustomers();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				// Handle exception and return error response
				return StatusCode(500, $"An error occurred while retrieving customers: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetCustomerById(string id)
		{
			try
			{
				var customer = _customerService.ReadCustomerById(id);
				if (customer == null)
				{
					return NotFound();
				}
				return Ok(customer);
			}
			catch (Exception ex)
			{
				// Handle exception and return error response
				return StatusCode(500, $"An error occurred while retrieving the customer: {ex.Message}");
			}
		}

		[HttpPost]
		public IActionResult CreateCustomer(Customer customer)
		{
			try
			{
				var result = _customerService.SaveCustomer(customer);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Handle exception and return error response
				return StatusCode(500, $"An error occurred while creating the customer: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCustomer(string id, Customer customer)
		{
			try
			{
				var existingCustomer = _customerService.ReadCustomerById(id);
				if (existingCustomer == null)
				{
					return NotFound();
				}
				customer._id = id;
				var result = _customerService.UpdateCustomer(customer);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Handle exception and return error response
				return StatusCode(500, $"An error occurred while updating the customer: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCustomer(string id)
		{
			try
			{
				var result = _customerService.DeleteCustomer(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Handle exception and return error response
				return StatusCode(500, $"An error occurred while deleting the customer: {ex.Message}");
			}
		}
	}
}
