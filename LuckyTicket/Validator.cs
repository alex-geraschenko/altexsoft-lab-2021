using System.Collections.Generic;
using System.Linq;

namespace LuckyTicket
{
    public record ValidationResult(bool IsValid, string ErrorMessage = null);

    public class Validator
    {
        public string ErrorMessage { get; private set; }

        public ValidationResult IsInputLengthValid(string input)
        {
            if (input.Length < 4)
            {
                return new ValidationResult(
                    IsValid: false,
                    ErrorMessage: "Your ticket is too short. It should be from 4 to 8 digits"
                );
            }

            if (input.Length > 8)
            {
                return new ValidationResult(
                    IsValid: false,
                    ErrorMessage: "Your ticket is too long. It should be from 4 to 8 digits"
                );
            }

            return new ValidationResult(IsValid: true);
        }

        public ValidationResult InputDigitsValid(IEnumerable<int> digits)
        {
            if (digits.Any(d => d > 9))
            {
                return new ValidationResult(
                    IsValid: false,
                    ErrorMessage: "Your ticket should contain just digits!"
                );
            }
            return new ValidationResult(IsValid: true);
        }
    }
}