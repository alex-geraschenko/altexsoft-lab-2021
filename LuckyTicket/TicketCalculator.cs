using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyTicket
{
    public class TicketCalculator
    {
        private readonly Validator _validator;
        private readonly Logger _logger;

        public TicketCalculator(Validator validator, Logger logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public bool Calculate(string input)
        {
            var digits = GetDigitsFromInput(input);

            digits = NormalizeDigits(digits);

            var (sum1, sum2) = GetSums(digits);

            return sum1 == sum2;
        }

        private IEnumerable<int> GetDigitsFromInput(string input)
        {
            var validationResult = _validator.IsInputLengthValid(input);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }
            return input.ToCharArray().Select(s => s - '0').ToArray();
        }

        private IEnumerable<int> NormalizeDigits(IEnumerable<int> digits)
        {
            var validationResult = _validator.InputDigitsValid(digits);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            var result = new List<int>(digits);
            if (result.Count % 2 != 0)
            {
                result.Insert(0, 0);
            }

            _logger.Log($"Digits in ticket number: {string.Join(",", result)}");

            return result;
        }

        private (int Sum1, int Sum2) GetSums(IEnumerable<int> digits)
        {
            var halfOfNumber = digits.Count() / 2;
            var sum1 = digits.Take(halfOfNumber).Sum();
            var sum2 = digits.Skip(halfOfNumber).Sum();

            _logger.Log($"Sum1: {sum1}, Sum2: {sum2}");

            return (sum1, sum2);
        }
    }
}