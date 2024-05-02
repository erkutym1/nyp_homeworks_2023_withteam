using System;
using System.Linq;

namespace Pet
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            List<string> pets = new List<string>();
            pets.Add("Kedi");
            pets.Add("Sarıkız");
            pets.Add("Cambaz");
            pets.Add("Renkli");
            pets.Add("Saçlı");
            pets.Add("Cambaz");
            pets.Add("Su");
            pets.Add("Tomy");
            pets.Add("Tom");
            pets.Add("Aslan Alex");
            pets.Add("Bakmalık Balık");


            IEnumerable<string> SortedByLength =
            from pet in pets orderby pet.Length ascending
            select pet;

            IEnumerable<string> SortedByLengthDesc =
            from pet in pets orderby pet.Length descending
            select pet;

            foreach(string result in SortedByLength)
            {
                Console.Write($"{result}\n");
            }
            Console.Write("\n");
            foreach(string result in SortedByLengthDesc)
            {
                Console.Write($"{result}\n");
            }
            Console.Write("\n");
            Console.Write($"{pets.Distinct<string>().Count<string>()}\n");
        }
    }
}