using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class OrderedShake
    {
        [BsonElement("shakeId")]
        public string Id { get; set; }

        [BsonElement("shakeName"), BsonRequired, MaxLength(20)]
        public string Name { get; set; }

        [BsonElement("price"), BsonRequired]
        public double Price { get; set; }

        
       
        public OrderedShake(string id,string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        
        
    }
}
