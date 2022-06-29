using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Domain
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("User")]
        [BsonRepresentation(BsonType.String)]
        public string User { get; set; }
        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }
        [BsonElement("MachineId")]
        [BsonRepresentation(BsonType.String)]
        public string MachineId { get; set; }
        [BsonElement("License")]
        [BsonRepresentation(BsonType.String)]
        public string License { get; set; }
        [BsonElement("ValidTo")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ValidTo { get; set; }
    }
}
