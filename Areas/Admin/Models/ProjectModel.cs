using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Donation.Areas.Admin.Models
{
    public class ProjectModel
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
