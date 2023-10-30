using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashRegister.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id;

        [BsonElement("orderedShakes")]
        private Dictionary<Shake, double> _shakes;
             

        [BsonElement("totalPrice")]
        private double _totalPrice;

        [BsonElement("clientName")]
        private string _clientName;

        [BsonElement("date")]
        private DateTime _date;

        [BsonElement("creationTime")]
        private DateTime _creationTime;

        [BsonElement("endTime")]
        private DateTime _endTime;

        [BsonElement("discounts")]
        private List<Discount> _discounts;

        public double TotalPrice
        {
            get { return _totalPrice; }
        }

        public string Id { get; internal set; }

        public Order(Dictionary<Shake, double> shakes, double price, string clientName, DateTime date, List<Discount> discounts)
        {
            _id = new Guid().ToString();
            _shakes = shakes;
            _totalPrice = price;
            _clientName = clientName;
            _date = date;
            _discounts = discounts;
        }
    }
}
