using System.ComponentModel.DataAnnotations;

namespace CashRegister.Dto
{

    public class OrderedShakeDto
    {
        private string _name;
        private double _price;

        [Required(ErrorMessage = "Name of shake is required"),MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z &]+$", ErrorMessage = "Use letters only please")]
        public string Name { get { return _name; } }

        [Required(ErrorMessage = "Price of shake is required")]
        [Range(1.00, 100.00, ErrorMessage = "Use only number between 1.00 to 100.00.")]
        public double Price { get { return _price; } }

        public OrderedShakeDto(string name, double price)
        {
            _name = name;
            _price = price;
        }
    }
}
