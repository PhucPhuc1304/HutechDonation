using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Web_Donation.Models
{
    public class Details
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IDProduct { get; set; } // Mã dự án
        public string Status { get; set; }
        public DateTime TimeBegin { get; set; } // Thời gian bắt đầu tài trợ
        public string InfoProduct { get; set; } // Thông tin dự án

        public string InfoDetails { get; set; } // Hoàn cảnh

        public string TypeDonation { get; set; } // Cách thức hỗ trợ
        public string Image1 { get; set; } // Cách thức hỗ trợ
        public string Image2 { get; set; } // Cách thức hỗ trợ
        public string Image3 { get; set; } // Cách thức hỗ trợ


    }
}

