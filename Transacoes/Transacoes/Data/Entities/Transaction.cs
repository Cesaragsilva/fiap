using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Transacao.API.Entities
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Card { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }
    }
}
