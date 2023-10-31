using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CashRegister.Validation;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models

{
    public class Shake
    {
       
        private string _id;
        private string _name;
        private string _description;
        private double _smallPrice;
        private double _mediumPrice;
        private double _largePrice;

        [BsonId, BsonElement("Id")]
        public string Id { get { return _id; } }

        [BsonElement("name"), BsonRequired, MaxLength(20)]
        public string Name { get{ return _name; } }

        [BsonElement("description"), BsonRequired, MaxLength(100)]
        public string Description { get { return _description; } }

        [BsonElement("smallPrice"), BsonRequired]
        public double SmallPrice { get { return _smallPrice; } }

        [BsonElement("mediumPrice"), BsonRequired]
        public  double MediumPrice { get { return _mediumPrice; } }

        [BsonElement("largePrice"), BsonRequired]
        public  double largePrice { get { return _largePrice; } }

        
        public Shake(string name, string description, double smallPrice, double mediumPrice, double largePrice)
        {
            _id = Guid.NewGuid().ToString();
            this._name = name;
            this._description = description;
            _smallPrice = smallPrice;
            _mediumPrice = mediumPrice;
            _largePrice = largePrice;
        }
    }
}
