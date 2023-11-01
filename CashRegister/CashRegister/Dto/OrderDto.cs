using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CashRegister.Models;

namespace CashRegister.Dto
{
    public class OrderDto
    {
        private List<OrderedShakeDto> _shakes;
        private string _name;
        private List<DiscountDto> _discounts;

        [Required(ErrorMessage = "must enter shake to the order")]
        public List<OrderedShakeDto> Shakes
        {
            get { return _shakes; }
            private set
            {
                if (value != null && value.Count() <= 10)
                {
                    _shakes = value;
                }
            }
        }

        [Required(ErrorMessage ="ClientName is required"), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        public string Name { get { return _name; } }
        
        
        public List<DiscountDto> Discounts

        {
            get { return _discounts; }

        }


        public OrderDto(List<OrderedShakeDto> shakes, string name, List<DiscountDto> discounts)
        {
            _shakes = shakes;
            _name = name;
            _discounts = discounts;
        }

    }
}
