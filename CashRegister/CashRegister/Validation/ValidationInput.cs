using CashRegister.Models;
using System.Text.RegularExpressions;
using CashRegister.Services;
namespace CashRegister.Validation
{
    public class ValidationInput
    {

       public static void CheckOrder(Order newOrder)
        {
            try
            {
                CheckVaild(newOrder);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private static void CheckVaild(Order newOrder)
        {
            CheckIfNull(newOrder);
            CheckName(newOrder.Name);
            CheckShakes(newOrder.Shakes);
        }
        private static void CheckIfNull(Order newOrder)
        {
            if(newOrder == null)
            {
                throw new ArgumentNullException("the new order is empty.");
            }
        }
        private static void CheckName(string name)
        {
            if (!string.IsNullOrEmpty(name)) 
            {
                throw new Exception("the client name is required.");
            }
            if(!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new Exception("the name must conatin only letters")
            }
        }

        private static void CheckOrderShake(OrderedShake orderedShake)
        {
            if(orderedShake == null)
            {
                throw new Exception("invalid ordered shake.");
            }
            var id = GetShakeIdByName(orderedShake.Name)
            if(id == null)
            {
                throw new Exception("invalid Shake");
            }
            else
            {
                oredrShake.Id == id;
            }
               
        }

        private static void CheckShakes(List<OrderedShake> shakes)
        {
            shakes.ForEach(shake => CheckOrderShake(shake));
        }
    }
}
