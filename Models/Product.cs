using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Web_Donation.Models
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Producid { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Images { get; set; }
		

		public decimal Target { get; set; }
	}
}
