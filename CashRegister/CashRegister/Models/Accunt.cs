namespace CashRegister.Models
{
    public class Accunt
    {
        public List<Order> orders;
        public double totalPrice;

        public Accunt()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            totalPrice += order.TotalPrice;
        }
    }
}
