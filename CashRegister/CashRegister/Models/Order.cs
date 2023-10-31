using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashRegister.Models
{
    public class Order
    {
        [BsonElement("id")]
        private string _id;

        [BsonElement("orderedShakes")]
        private List<OrderedShake> _shakes;

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

        public List<OrderedShake> Shakes { get { return _shakes; } }
        public string Name
        {
            get { return _clientName; }
            set
            {
                if()
            }
        }

        public string Id { get { return _id; } { set }
        public double TotalPrice
        {
            get { return _totalPrice; }
        }

        public string Id { get; internal set; }

        public Order(List<OrderedShake> shakes, double price, string clientName, DateTime date, List<Discount> discounts)
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
