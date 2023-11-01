using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Discount
    {
        private string _id;
        private double _percentage;
        private string _discription;

        [BsonElement("Id")]
        public string Id { get { return _id; } }

        [BsonElement("Precentage")]
        [Required]
        public double Percentage { get { return _percentage; } }

        [BsonElement("Discription")]
        [Required]
        public string Discription { get { return _discription; } }

        public Discount(double percentage, string description)
        {
            _id = Guid.NewGuid().ToString();
            _percentage = percentage;
            _discription = description;
        }

    }
    
}
