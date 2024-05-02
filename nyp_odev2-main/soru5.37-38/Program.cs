using System;

namespace Calculator
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            factorial_prompt();
            Console.WriteLine("\n---\n");
            e_prompt();
        }

        internal static void factorial_prompt()
        {
            Console.Write("Enter a number to calculate the factorial of: ");
            try
            {
                uint number = 0;
                number = uint.Parse(Console.ReadLine());

                Console.Write("\nResult: {0}\n", Operation.Factorial(number));
            }
            catch
            {
                Console.Write("\nYou must enter a natural number.\n");
                return;
            }
        }

        internal static void e_prompt()
        {
            uint approximation = 0;
            Console.Write("Enter the number of steps to be performed to calculate e: ");
            try
            {
                approximation = Convert.ToUInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You must enter a natural number.");
                return;
            }
            Console.Write("\n");

            try
            {
                decimal calculation = Operation.E_Number(approximation);
                Console.WriteLine("Our calculation of e:\t{0}", calculation);
                Console.WriteLine("Math library's e:\t{0}", Math.E);
                Console.WriteLine("\nRelative error:\t\t{0}",
                                    Operation.RelativeError(calculation, (decimal)Math.E));
            }
            catch
            {
                Console.WriteLine("Calculation failed.");
            }
        }
    }

    internal class Operation
    {
        internal static long Factorial(uint number)
        {
            if (number <= 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        internal static decimal E_Number(uint step)
        {
            decimal eNumber = 0;

            if (step <= 1)
            {
                return step;
            }
            else
            {
                for(uint i = 0; i < step; i++)
                {
                    eNumber += ((decimal)1.0 / (decimal)Factorial(i));
                }
                return eNumber;
            }  
        }

        internal static decimal RelativeError(decimal calculation, decimal theoretical)
        {
            return (Math.Abs(calculation - theoretical) / theoretical);
        }
    }
}