using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        [Required(ErrorMessage = "Shake name is required")]
        [RegularExpression(@"^[a-zA-Z &]+$", ErrorMessage = "Use letters and '&' only please ")]
        public string Name { get{ return _name; } }

        [BsonElement("description"), BsonRequired, MaxLength(100)]
        [Required(ErrorMessage = "Shake description is required")]
        [RegularExpression(@"^[a-zA-Z !.,]+$", ErrorMessage = "Use letters and '!' and '.' and ',' only please")]
        public string Description { get { return _description; } }

        [BsonElement("smallPrice"), BsonRequired]
        [Range(1.00,100.00, ErrorMessage ="number must be between 1.00 to 100.00.")]
        public double SmallPrice { get { return _smallPrice; } }

        [BsonElement("mediumPrice"), BsonRequired]
        [Range(1.00, 100.00, ErrorMessage = "number must be between 1.00 to 100.00.")]
        public  double MediumPrice { get { return _mediumPrice; } }

        [BsonElement("largePrice"), BsonRequired]
        [Range(1.00, 100.00, ErrorMessage = "number must be between 1.00 to 100.00.")]
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
