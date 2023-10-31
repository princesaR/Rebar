using System.Text.RegularExpressions;

namespace CashRegister.Validation
{
    public class ValidationCheck
    {
        
        public static void IsShakeNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name Shake is empty or null");
            }
            if (!Regex.IsMatch(name, @"^[a-zA-Z& ]+$"))
            {
                throw new ArgumentException("");
            }
        }

        public static void IsDesciptionValid(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description");
            }
            if(!Regex.IsMatch(description,@"^[a-zA-Z! ]+$"))
            {
                throw new ArgumentException("the discription is invalid.");
            }
            
        }



        public static void IsClientNameValid( string clientName)
        {
            if (string.IsNullOrEmpty(clientName))
            {
                throw new ArgumentNullException("client name is empty.");

            }
            if (!Regex.IsMatch(clientName, @"^[a-zA-Z]+$"))
            {
                throw new InvalidOperationException("client's name is invaild");
            }
        }
    }
}
