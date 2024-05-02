using System;
internal class Program
{
    internal static int SumOfDigits(int number)
    {
        if(number<10)
        {
            return number;
        }

        return ((number%10)+SumOfDigits(number/10));
    }
    internal static int Main()
    {
        int number;
        int sum;
        Console.Write("\nPlease enter a number: \n>");
        number= Convert.ToInt32(Console.ReadLine());
        while(number>99999||number<10)
        {
            Console.Write("\nInvalid input: Please enter a number that is greater than 9 and less than 100000.\n>");
            number= Convert.ToInt32(Console.ReadLine());
        }
        sum= SumOfDigits(number);
        Console.Write($"\n{sum}");
        return 0; 
    }    
}

