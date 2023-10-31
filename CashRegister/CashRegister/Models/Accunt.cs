using MongoDB.Bson.Serialization.Attributes;

namespace CashRegister.Models
{
    public class Accunt
    {
        [BsonElement("id")]
        private string _id; 

        [BsonElement("orders")]
        private List<Order> orders;

        [BsonElement("totalPrice")]
        private double totalPrice;

        public Accunt()
        {
            orders = new List<Order>();
        }

        public string Id { get; internal set; }

       
    }
}
