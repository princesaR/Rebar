using MongoDB.Bson.Serialization.Attributes;

namespace CashRegister.Models
{
    public class Discount
    {
        private string _id;
        private double _percentage;
        private string _discription;

        [BsonElement("discountId")]
        public string Id { get { return _id; } }

        [BsonElement("precentage")]
        public double Percentage { get { return _percentage; } }

        [BsonElement("discription")]
        public string Discription { get { return _discription; } }

        public Discount(double percentage, string description)
        {
            _id = Guid.NewGuid().ToString();
            _percentage = percentage;
            _discription = description;
        }

    }
    
}
