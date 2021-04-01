using System.Collections.Generic;
using System.Linq;

namespace LuckyTicket
{
    public class Validator
    {
        public string ErrorMessage { get; private set; }

        public bool IsInputLengthValid(string input)
        {
            if (input.Length < 4)
            {
                ErrorMessage = "Your ticket is too short. It should be from 4 to 8 digits";
                return false;
            }

            if (input.Length > 8)
            {
                ErrorMessage = "Your ticket is too long. It should be from 4 to 8 digits";
                return false;
            }

            return true;
        }

        public bool InputDigitsValid(IEnumerable<int> digits)
        {
            if (digits.Any(d => d > 10))
            {
                ErrorMessage = "Your ticket should contain just digits!";
                return false;
            }
            return true;
        }
    }
}