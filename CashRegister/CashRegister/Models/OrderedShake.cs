using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class OrderedShake
    {
        private string _id;
        private string _name;
        private double _price;

        [BsonElement("id")]
        public string Id { get { return _id; }  }

        [BsonElement("Name")]
        [Required]
        public string Name { get { return _name; } }

        [BsonElement("Price")]
        [Required]
        public double Price { get { return _price; } }

        public OrderedShake(string name, double price)
        {
            _id = Guid.NewGuid().ToString();
            _name = name;
            _price = price;
        }
    }
}
