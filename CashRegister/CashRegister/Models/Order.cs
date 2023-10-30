namespace CashRegister.Models
{
    public class Order
    {
        private string _id;
        private Dictionary<Shake, double> _shakes;
        private double _totalPrice;
        private string _clientName;
        private DateTime _date;
        private double _discounts;

        public double TotalPrice
        {
            get { return _totalPrice; }
        }
        public Order(Dictionary<Shake, double> shakes, double price, string clientName, DateTime date, double discounts)
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
