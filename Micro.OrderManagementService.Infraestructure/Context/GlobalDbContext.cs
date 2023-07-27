using Micro.OrderManagementService.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Micro.OrderManagementService.Infraestructure.Context
{
	public class GlobalDbContext
	{
		private readonly IMongoDatabase _database;

		public GlobalDbContext(IOptions<MongoSettings> options)
		{
			var client = new MongoClient(options.Value.ConnectionString);
			_database = client.GetDatabase(options.Value.DatabaseName);
		}

		public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Tbl_Customer");
		public IMongoCollection<Product> Products => _database.GetCollection<Product>("Tbl_Product");
		public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Tbl_Order");
		public IMongoCollection<OrderLine> OrderLines => _database.GetCollection<OrderLine>("Tbl_OrderLine");



	}
}
