using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Order
    {
      
        private string _id;
        private List<OrderedShake> _shakes;
        private double _totalPrice;
        private string _clientName;
        private DateTime _creationTime;
        private DateTime _endTime;
        private List<Discount> _discounts;



        [BsonElement("id")]
        public string Id { get { return _id; } }

        [BsonElement("orderedShakes"), BsonRequired ]
        public List<OrderedShake> Shakes { get { return _shakes; } }

        [BsonElement("totalPrice")]
        public double TotalPrice { get { return _totalPrice; } }

        [BsonElement("clientName"), BsonRequired, MaxLength(20)]
        public string ClientName { get { return _clientName; } }

        [BsonElement("creationTime"), BsonRequired]
        public DateTime CreationTime { get { return _creationTime; } }

        [BsonElement("endTime"), BsonRequired]
        public DateTime Endtime { get { return _endTime; } }

        [BsonElement("discounts")]
        public List<Discount> Discount { get { return _discounts; } }


        public Order(List<OrderedShake> shakes,  string clientName, DateTime creationTime, List<Discount> discounts)
        {
            _id = Guid.NewGuid().ToString();
            _shakes = shakes;
            _totalPrice = shakes.Sum(x => x.price);
            _clientName = clientName;
            _creationTime = DateTime.Now;
            _discounts = discounts;
        }

      
    }
}
