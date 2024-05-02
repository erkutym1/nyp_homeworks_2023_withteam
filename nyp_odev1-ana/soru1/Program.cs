using System;

namespace soru1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            int yarıçap = 0;
            if (args.Length >= 1)
            {
                yarıçap = Convert.ToInt32(args[0]);
            }
            else
            {
                Console.Write("Dairenin yarıçapını girin: ");
                yarıçap = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
            }
            Console.WriteLine("Çap: {0}", (2 * yarıçap));
            Console.WriteLine("Çevre: {0}", (2 * Math.PI * yarıçap));
            Console.WriteLine("Alan: {0}", (Math.PI * Math.Pow(yarıçap,2)));
        }
    }
}
