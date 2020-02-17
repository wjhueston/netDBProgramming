using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assign_01_CSVIO
{
    class Reader
    {
        public int idNumber;
        public string innerMenu = "Y";
        public string summary;
        public string status;
        public string priority;
        public string submitter;
        public string assigned;
        public string watching;
        public Reader(int id)
        {
            idNumber = id;
        }
        public void reader()
        {
            string file = "tickets.csv";
            StreamWriter sw = new StreamWriter(file, append: true);
            
            for(int i = 0; i<5; i++)
            {
                
                
                    Console.WriteLine("Enter a summary");
                    summary = Console.ReadLine();
                    sw.Write($"{idNumber},{summary},");
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
                    idNumber++;
                    Console.WriteLine("New ticket? (Y/N)");
                    innerMenu = Console.ReadLine();
                    if (innerMenu == "N") { break; }
                
            }
            sw.Close();

        }
    }
}
