using MongoDB.Bson.Serialization.Attributes;

namespace CashRegister.Models
{
    public class Accunt
    {
       
        private string _id;
        private List<Order> _orders;
        private double _totalPrice;
        private DateTime _day;

        [BsonElement("id")]
        public string Id { get { return _id; } }

        [BsonElement("orders")]
        public List<Order> Orders { get { return _orders; } }

        [BsonElement("totalPrice")]
        public double TotalPrice { get { return _totalPrice; } }

        [BsonElement("day")]
        public DateTime Day { get { return _day; } }

        public Accunt()
        {
            _orders = new List<Order>();
            _totalPrice = 0;
            _day = DateTime.Now;
        }

        
        

       
    }
}
