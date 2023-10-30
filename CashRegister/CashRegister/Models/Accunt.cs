using MongoDB.Bson.Serialization.Attributes;

namespace CashRegister.Models
{
    public class Accunt
    {
        [BsonElement("orders")]
        public List<Order> orders;

        [BsonElement("totalPrice")]
        public double totalPrice;

        public Accunt()
        {
            orders = new List<Order>();
        }

        public string Id { get; internal set; }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            totalPrice += order.TotalPrice;
        }
    }
}
