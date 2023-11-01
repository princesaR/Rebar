using MongoDB.Bson.Serialization.Attributes;

namespace CashRegister.Models
{
    public class Accunt
    {
       
        
        private List<Order> _orders;
        private double _totalPrice;

        public List<Order> Orders { get { return _orders; } }
        public double TotalPrice { get { return _totalPrice; } }

       
        public Accunt()
        {
            _orders = new List<Order>();
            _totalPrice = 0;
        }

        
        

       
    }
}
