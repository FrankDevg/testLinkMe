using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Micro.OrderManagementService.Domain.Models
{
	public class Order
	{
		[BsonId]
		public string Id { get; set; }

		[BsonElement("OrderDate")]
		public DateTime OrderDate { get; set; }

		[BsonElement("SoldBy")]
		public string SoldBy { get; set; }

		[BsonElement("Total")]
		public decimal Total { get; set; }

		[BsonElement("MgGr")]
		public string MgGr { get; set; }

		[BsonElement("CustomerId")]
		public string CustomerId { get; set; }
	}
}
