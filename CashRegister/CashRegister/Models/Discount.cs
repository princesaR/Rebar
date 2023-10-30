namespace CashRegister.Models
{
    public class Discount
    {
        private string _id;
        private double _percentage;
        private string _discription;

        public Discount(double percentage, string description)
        {
            _id = new Guid().ToString();
            _percentage = percentage;
            _discription = description;
        }

    }
    
}
