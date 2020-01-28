using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assign_01_CSVIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = ("tickets.csv");
            int outerMenu;
            do
            {
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Write");
                outerMenu = Convert.ToInt32(Console.ReadKey());
                if(outerMenu == 1)
                {
                    //TODO Read Logic
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string currentLine = sr.ReadLine();
                            string[] elements = currentLine.Split(',');
                            Console.WriteLine($"ID: {elements[0]}");
                            Console.WriteLine($"Summary: {elements[1]}");
                            Console.WriteLine($"Status: {elements[2]}");
                            Console.WriteLine($"Priority: {elements[3]}");
                            Console.WriteLine($"Submitter: {elements[4]}");
                            Console.WriteLine($"Assigned: {elements[5]}");
                            Console.WriteLine($"Watching: {elements[6]}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("File not found");
                    }
                }
                else
                {
                    StreamWriter sw = new StreamWriter(file, append: true);
                    string innerMenu = "Y";
                    while (innerMenu != "N")
                    {
                        for (int i=0; i < 5; i++)
                        {
                            Console.WriteLine("New Ticket?(Y/N)");
                            innerMenu = Console.ReadLine();
                            Console.WriteLine("Enter a summary");
                            //More Write Code, experiment with CSV files
                        }

                        
                    }

                }
            }
            while (outerMenu == 1 || outerMenu == 2);
        }
    }
}

