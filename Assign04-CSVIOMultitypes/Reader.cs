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
        public string software;
        public double cost;
        public string reason;
        public double estimate;
        public string projectName;
        public string dueDate;
        public Reader(int id)
        {
            idNumber = id;
        }
        public void reader()
        {
            Console.WriteLine("1. New Ticket");
            Console.WriteLine("2. New Enhancement");
            Console.WriteLine("3. New Task");
            string menu = Console.ReadLine();
            if(menu == "1") 
            {
                string file = "tickets.csv";
                if (!File.Exists(file))
                {
                    File.Create(file);

                }
                StreamWriter sw = new StreamWriter(file, append: true);

                for (int i = 0; i < 5; i++)
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
                    if (innerMenu == "N") { Console.Clear(); break; }

                }
                sw.Close();
            }
            else if(menu == "2")
            {
                string file = "enhancements.csv";
                if (!File.Exists(file))
                {
                    File.Create(file);

                }
                StreamWriter sw = new StreamWriter(file, append: true);

                for (int i = 0; i < 5; i++)
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
                    sw.Write($"{watching},");
                    Console.WriteLine("Enter the software");
                    software = Console.ReadLine();
                    sw.Write($"{software},");
                    Console.WriteLine("Enter the cost");
                    cost = Convert.ToDouble(Console.ReadLine());
                    sw.Write($"{cost:C2},");
                    Console.WriteLine("Enter the reason");
                    reason = Console.ReadLine();
                    sw.Write($"{reason},");
                    Console.WriteLine("Enter the estimate");
                    estimate = Convert.ToDouble(Console.ReadLine());
                    sw.Write($"{estimate:C2}\n");
                    idNumber++;
                    Console.WriteLine("New enhancement? (Y/N)");
                    innerMenu = Console.ReadLine();
                    if (innerMenu == "N") { Console.Clear();  break; }

                }
                sw.Close();
            }
            else if(menu == "3")
            {
                string file = "tasks.csv";
                if (!File.Exists(file))
                {
                    File.Create(file);

                }
                StreamWriter sw = new StreamWriter(file, append: true);

                for (int i = 0; i < 5; i++)
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
                    sw.Write($"{watching},");
                    Console.WriteLine("Enter the Project Name");
                    projectName = Console.ReadLine();
                    sw.Write($"{projectName},");
                    Console.WriteLine("Enter the Due Date. Please use the following format: \"MM/DD/YYYY\"");
                    dueDate = Console.ReadLine();
                    sw.Write($"{dueDate}\n");
                    idNumber++;
                    Console.WriteLine("New task? (Y/N)");
                    innerMenu = Console.ReadLine();
                    if (innerMenu == "N") { Console.Clear();  break; }

                }
                sw.Close();
            }
            

        }
    }
}
