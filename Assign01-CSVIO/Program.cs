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
            string[] elements;
            int idCounter = 1;
            do
            {
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Write");
                outerMenu = Convert.ToInt32(Console.ReadLine());
                if(outerMenu == 1)
                {
                    
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        using (sr) {
                            string headLine = sr.ReadLine();
                            
                            while (!sr.EndOfStream)
                            {
                                string currentLine = sr.ReadLine();
                                elements = currentLine.Split(',');
                                Console.WriteLine($"ID: {elements[0]}");
                                Console.WriteLine($"Summary: {elements[1]}");
                                Console.WriteLine($"Status: {elements[2]}");
                                Console.WriteLine($"Priority: {elements[3]}");
                                Console.WriteLine($"Submitter: {elements[4]}");
                                Console.WriteLine($"Assigned: {elements[5]}");
                                Console.WriteLine($"Watching: {elements[6]}");
                                Console.WriteLine();
                                idCounter = Convert.ToInt32(elements[0]) + 1;
                            
                            }
                        }
                        sr.Close();
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
                    string summary;
                    string status;
                    string priority;
                    string submitter;
                    string assigned;
                    string watching;
                    for (int i = 0; i < 5; i++)
                    {
                        
                        
                            Console.WriteLine("Enter a summary");
                            summary = Console.ReadLine();
                            sw.Write($"{idCounter},{summary},");
                            Console.WriteLine("Enter the status");
                            status = Console.ReadLine();
                            sw.Write($"{status},");
                            Console.WriteLine("Enter the priority");
                            priority = Console.ReadLine();
                            sw.Write($"{priority},");
                            Console.WriteLine("Enter the submitter");
                            submitter = Console.ReadLine();
                            sw.Write($"{submitter},");
                            Console.WriteLine("Enter the assigned tech");
                            assigned = Console.ReadLine();
                            sw.Write($"{assigned},");
                            Console.WriteLine("Enter the watchers");
                            watching = Console.ReadLine();
                            sw.Write($"{watching}\n");
                            idCounter++;
                            Console.WriteLine("New ticket? (Y/N)");
                            innerMenu = Console.ReadLine();
                            if (innerMenu == "N") { break; }
                        
                        
                            
                    }
                    sw.Close();
                }
            }
            while (outerMenu == 1 || outerMenu == 2);
            
        }
    }
}

