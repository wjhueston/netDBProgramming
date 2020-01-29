using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            double dave;
            double jerry;
            Console.WriteLine("how much was your bill");
            dave = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("how cheap are you?");
            jerry = Convert.ToInt32(Console.ReadLine());
            dave = dave * jerry;
            Console.WriteLine($"Give your waitress ${dave}");
        }
    }
}
