using System;
using static System.Console;

namespace LuckyTicket
{
    class Program
    {
        private static TicketCalculator _calculator = new(new Validator(), new Logger());

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

                try
                {
                    var isLucky = _calculator.Calculate(input);
                    if (isLucky)
                    {
                        WriteLine("Congratulations! Your ticket is lucky");
                    }
                    else
                    {
                        WriteLine("Sorry! Your ticket is not lucky");
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        private static string GetInput()
        {
            Write("Please enter your ticket number or 'q' for exit: ");

            return ReadLine();
        }

        private static bool RequestToExit(string input)
        {
            return input == "q";
        }
    }
}