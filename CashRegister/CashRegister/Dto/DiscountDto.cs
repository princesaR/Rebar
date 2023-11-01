using System.ComponentModel.DataAnnotations;

namespace CashRegister.Dto
{
    public class DiscountDto
    {
        private double _percentage;
        private string _discription;

        [Required(ErrorMessage = "Percentage is required"), Range(0, 100, ErrorMessage = "Please enter a value between 1-100")]
        public double Percentage { get { return _percentage; } }

        [Required(ErrorMessage = "Discription of discount is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Discription { get { return _discription; } }

        public DiscountDto(double percentage, string discription)
        {
            _percentage = percentage;
            _discription = discription;
        }
    }
}
