using System.Linq;
using static System.Console;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to the Lucky Ticket calculator!");

            while (true)
            {
                Write("Please enter your ticket number or 'q' for exit: ");

                var input = ReadLine();

                if (input == "q")
                {
                    WriteLine("Good bye!");
                    break;
                }

                // validate
                if (input.Length < 4)
                {
                    WriteLine("Your ticket is too short. It should be from 4 to 8 digits");
                    continue;
                }

                if (input.Length > 8)
                {
                    WriteLine("Your ticket is too long. It should be from 4 to 8 digits");
                    continue;
                }

                var digits = input.ToCharArray()
                    .Select(s => s - '0')
                    .ToList();

                if (digits.Any(d => d > 10))
                {
                    WriteLine("Your ticket should contain just digits!");
                    continue;
                }

                if (digits.Count % 2 != 0)
                {
                    digits.Insert(0, 0);
                }

                WriteLine($"Digits in ticket number: {string.Join(",", digits)}");

                var sum1 = digits.Take(digits.Count / 2).Sum();
                var sum2 = digits.Skip(digits.Count / 2).Sum();

                WriteLine($"Sum1: {sum1}, Sum2: {sum2}");

                if (sum1 == sum2)
                {
                    WriteLine("Congratulations! Your ticket is lucky");
                }
                else
                {
                    WriteLine("Sorry! Your ticket is not lucky");
                }
            }
        }
    }
}
