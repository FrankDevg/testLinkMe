using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micro.OrderManagementService.Application.Interfaces;
using MicroBroker.OrderManagementService.Domain.Interfaces; // Importa la interfaz
using Micro.OrderManagementService.Domain.Models;

namespace Micro.OrderManagementService.Application.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository; // Usa la interfaz en lugar de la clase concreta

		public CustomerService(ICustomerRepository customerRepository) // Inyecta la interfaz en el constructor
		{
			_customerRepository = customerRepository;
		}

		public IEnumerable<Customer> ReadCustomers()
		{
			return _customerRepository.ReadCustomers();
		}

		public int SaveCustomer(Customer customer)
		{
			return _customerRepository.SaveCustomer(customer);
		}

		public int UpdateCustomer(Customer customer)
		{
			return _customerRepository.UpdateCustomer(customer);
		}

		public int DeleteCustomer(string id)
		{
			return _customerRepository.DeleteCustomer(id);
		}

		public Customer ReadCustomerById(string id)
		{
			return _customerRepository.ReadCustomerById(id);
		}
	}
}
