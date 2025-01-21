using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace proba
{
    [Serializable]
    public class Termekek
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("product_code"), BsonRepresentation(BsonType.String)]
        public string ProductCode { get; set; }

        [BsonElement("product_name"), BsonRepresentation(BsonType.String)]
        public string ProductName { get; set; }

        [BsonElement("price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("zosPred"), BsonRepresentation(BsonType.Decimal128)]
        public decimal ZosPred { get; set; }

        [BsonElement("prijem"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Prijem { get; set; }

        [BsonElement("uzavZos"), BsonRepresentation(BsonType.Decimal128)]
        public decimal UzavZos { get; set; }
    }
}
