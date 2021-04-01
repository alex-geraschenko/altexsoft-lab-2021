using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to the Lucky Ticket calculator!");
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                string input = GetInput();

                if (RequestToExit(input))
                {
                    WriteLine("Good bye!");
                    break;
                }

                if (!ValidateInputLength(input))
                {
                    continue;
                }

                var digits = GetDigitsFromInput(input);

                if (!ValidateInputDigits(digits))
                {
                    continue;
                }

                digits = NormalizeDigits(digits);

                if (ValidateTicketIsLucky(digits))
                {
                    WriteLine("Congratulations! Your ticket is lucky");
                }
                else
                {
                    WriteLine("Sorry! Your ticket is not lucky");
                }
            }
        }

        private static string GetInput()
        {
            Write("Please enter your ticket number or 'q' for exit: ");

            var input = ReadLine();

            return input;
        }

        private static bool RequestToExit(string input)
        {
            return input == "q";
        }

        private static bool ValidateInputLength(string input)
        {
            if (input.Length < 4)
            {
                WriteLine("Your ticket is too short. It should be from 4 to 8 digits");
                return false;
            }

            if (input.Length > 8)
            {
                WriteLine("Your ticket is too long. It should be from 4 to 8 digits");
                return false;
            }

            return true;
        }

        private static IEnumerable<int> GetDigitsFromInput(string input)
        {
            return input.ToCharArray().Select(s => s - '0').ToArray();
        }

        private static bool ValidateInputDigits(IEnumerable<int> digits)
        {
            if (digits.Any(d => d > 10))
            {
                WriteLine("Your ticket should contain just digits!");
                return false;
            }

            return true;
        }

        private static IEnumerable<int> NormalizeDigits(IEnumerable<int> digits)
        {
            var result = new List<int>(digits);
            if (result.Count % 2 != 0)
            {
                result.Insert(0, 0);
            }
            return result;
        }

        private static bool ValidateTicketIsLucky(IEnumerable<int> digits)
        {
            WriteLine($"Digits in ticket number: {string.Join(",", digits)}");

            var halfOfNumber = digits.Count() / 2;
            var sum1 = digits.Take(halfOfNumber).Sum();
            var sum2 = digits.Skip(halfOfNumber).Sum();

            WriteLine($"Sum1: {sum1}, Sum2: {sum2}");

            return sum1 == sum2;
        }
    }
}
