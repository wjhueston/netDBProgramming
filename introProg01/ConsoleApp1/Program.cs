using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}. Welcome to the tip calculator");
            Console.WriteLine("Enter the restaurant name");
            string restaurant = Console.ReadLine();
            Console.WriteLine("Enter the total");
            double total = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the tip amount as a decimal");
            double tipPercent = Convert.ToDouble(Console.ReadLine());
            double grandTotal = (tipPercent * total) + total;
            Console.WriteLine($"A {tipPercent*100}% tip of {total} is {tipPercent*total}.");
            Console.WriteLine($"The grand total is {grandTotal}");
            Console.WriteLine($"Thank you for dining at {restaurant}, {name}!");
        }
    }
}
