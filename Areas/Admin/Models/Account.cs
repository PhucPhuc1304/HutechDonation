using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Donation.Areas.Admin.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string roles { get; set; }
    }
}
