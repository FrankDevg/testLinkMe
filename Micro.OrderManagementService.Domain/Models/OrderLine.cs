using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Micro.OrderManagementService.Domain.Models
{
	public class OrderLine
	{
		[BsonId]
		public string Id { get; set; }

		[BsonElement("Quantity")]
		public int Quantity { get; set; }

		[BsonElement("UnitSalePrice")]
		public decimal UnitSalePrice { get; set; }

		[BsonElement("Subtotal")]
		public decimal Subtotal { get; set; }

		[BsonElement("OrderId")]
		public string OrderId { get; set; }

		[BsonElement("ProductId")]
		public string ProductId { get; set; }
	}
}
