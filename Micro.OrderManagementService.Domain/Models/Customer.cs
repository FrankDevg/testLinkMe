using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Micro.OrderManagementService.Domain.Models
{
	public class Customer
	{
		[BsonId]
		public string _id { get; set; }

		[BsonElement("cFirstName")]
		public string CFirstName { get; set; }

		[BsonElement("cLastName")]
		public string CLastName { get; set; }

		[BsonElement("cPhone")]
		public string CPhone { get; set; }

		[BsonElement("cStreet")]
		public string CStreet { get; set; }

		[BsonElement("cZipCode")]
		public string CZipCode { get; set; }
	}
}
