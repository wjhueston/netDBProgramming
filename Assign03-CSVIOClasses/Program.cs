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
            int idCounter = 0;
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
                                Ticket newTic = new Ticket(Convert.ToInt32(elements[0]),elements[1],elements[2],elements[3],elements[4],elements[5],elements[6]);
                                Console.WriteLine($"ID: {newTic.idNumber}");
                                Console.WriteLine($"Summary: {newTic.summary}");
                                Console.WriteLine($"Status: {newTic.status}");
                                Console.WriteLine($"Priority: {newTic.priority}");
                                Console.WriteLine($"Submitter: {newTic.submitter}");
                                Console.WriteLine($"Assigned: {newTic.assigned}");
                                Console.WriteLine($"Watching: {newTic.watchers}");
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
                    Reader newRead = new Reader(idCounter);
                    newRead.reader();
                        }
                        
                            
                    
                    
                
            }
            while (outerMenu == 1 || outerMenu == 2);
            
        }
    }
}

