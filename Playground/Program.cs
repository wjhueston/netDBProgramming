using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dave = new string[]
            {
                "tom",
                "richard",
                "stevy"
            };
            
            foreach(string jerr in dave)
            {
                Console.WriteLine($"Second Name is {dave}");
              
            }
        }
    }
}
