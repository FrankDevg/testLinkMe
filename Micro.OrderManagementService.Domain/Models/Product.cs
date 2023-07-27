using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Micro.OrderManagementService.Domain.Models
{
	public class Product
	{
		[BsonId]
		public string _id { get; set; }

		[BsonElement("UPC")]
		public string UPC { get; set; }

		[BsonElement("ProdName")]
		public string ProdName { get; set; }

		[BsonElement("MgGr")]
		public string MgGr { get; set; }

		[BsonElement("Model")]
		public string Model { get; set; }

		[BsonElement("UnitListPrice")]
		public decimal UnitListPrice { get; set; }

		[BsonElement("UnitsInStock")]
		public int UnitsInStock { get; set; }
	}
}
