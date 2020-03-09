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
            string enhanceFile = ("enhancements.csv");
            string taskFile = ("tasks.csv");
            string outerMenu;
            string[] elements;
            int idCounter = 0;
            do
            {
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Write");
                Console.WriteLine("3. Search");
                outerMenu = Console.ReadLine();
                if(outerMenu == "1")
                {
                    Console.WriteLine("Read Which File?");
                    Console.WriteLine("1. Tickets");
                    Console.WriteLine("2. Enhancements");
                    Console.WriteLine("3. Tasks");
                    string innerMenu = Console.ReadLine();
                    switch (innerMenu)
                    {
                        case "1":
                            if (File.Exists(file))
                            {
                                StreamReader sr = new StreamReader(file);
                                using (sr)
                                {
                                    string headLine = sr.ReadLine();

                                    while (!sr.EndOfStream)
                                    {

                                        string currentLine = sr.ReadLine();
                                        elements = currentLine.Split(',');
                                        Console.Clear();
                                        Ticket newTic = new Ticket(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6]);
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
                                File.Create(file);
                                StreamWriter sw = new StreamWriter(file);
                                sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity");
                                Console.WriteLine("File was not found. Created new file.");
                                sw.Close();
                            }
                            break;
                        case "2":
                            if (File.Exists(enhanceFile)) 
                            {
                                StreamReader sr = new StreamReader(enhanceFile);
                                using (sr) 
                                { 
                                    string headLine = sr.ReadLine();
                                    while (!sr.EndOfStream)
                                    {
                                        string currentLine = sr.ReadLine();
                                        elements = currentLine.Split(',');
                                        Console.Clear();
                                        Enhancement enhance = new Enhancement(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7], Convert.ToDouble(elements[8]), elements[9], Convert.ToDouble(elements[10]));
                                        Console.WriteLine($"ID: {enhance.idNumber}");
                                        Console.WriteLine($"Summary: {enhance.summary}");
                                        Console.WriteLine($"Status: {enhance.status}");
                                        Console.WriteLine($"Priority: {enhance.priority}");
                                        Console.WriteLine($"Submitter: {enhance.submitter}");
                                        Console.WriteLine($"Assigned: {enhance.assigned}");
                                        Console.WriteLine($"Watching: {enhance.watchers}");
                                        Console.WriteLine($"Software: {enhance.software}");
                                        Console.WriteLine($"Cost: {enhance.cost}");
                                        Console.WriteLine($"Reason: {enhance.reason}");
                                        Console.WriteLine($"Estimate: {enhance.estimate}");
                                        Console.WriteLine();
                                        idCounter = Convert.ToInt32(elements[0]) + 1;
                                    }
                                }
                                sr.Close();


                            }
                            else
                            {
                                File.Create(enhanceFile);
                                StreamWriter sw = new StreamWriter(enhanceFile);
                                sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate");
                                Console.WriteLine("File not found. Created new file.");
                                sw.Close();
                            }
                            break;
                        case "3":
                            if (File.Exists(taskFile))
                            {
                                StreamReader sr = new StreamReader(taskFile);
                                using (sr)
                                {
                                    string headLine = sr.ReadLine();
                                    while (!sr.EndOfStream)
                                    {
                                        string currentLine = sr.ReadLine();
                                        elements = currentLine.Split(',');
                                        Console.Clear();
                                        Task tasklet = new Task(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7], elements[8]);
                                        Console.WriteLine($"ID: {tasklet.idNumber}");
                                        Console.WriteLine($"Summary: {tasklet.summary}");
                                        Console.WriteLine($"Status: {tasklet.status}");
                                        Console.WriteLine($"Priority: {tasklet.priority}");
                                        Console.WriteLine($"Submitter: {tasklet.submitter}");
                                        Console.WriteLine($"Assigned: {tasklet.assigned}");
                                        Console.WriteLine($"Watching: {tasklet.watchers}");
                                        Console.WriteLine($"Project Name: {tasklet.projectName}");
                                        Console.WriteLine($"Due Date: {tasklet.dueDate}");
                                        Console.WriteLine();
                                        idCounter = Convert.ToInt32(elements[0]) + 1;
                                    }
                                }
                                sr.Close();


                            }
                            else
                            {
                                File.Create(taskFile);
                                StreamWriter sw = new StreamWriter(taskFile);
                                sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate");
                                Console.WriteLine("File not found. Created new file.");
                                sw.Close();
                            }
                            break;

                    }


                }

                else if(outerMenu == "2")
                {
                    Reader newRead = new Reader(idCounter);
                    newRead.reader();
                        }
                else
                {
                    
                    Console.Clear();
                    Console.Write("Enter a search term: ");
                    Console.WriteLine();
                    string search = Console.ReadLine();
                    search = search.ToUpper();
                    int matchCount = 0;
                    StreamReader sr = new StreamReader(file);
                    StreamReader er = new StreamReader(enhanceFile);
                    StreamReader tr = new StreamReader(taskFile);
                    using (sr)
                    {
                        string headLine = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            string currentLine = sr.ReadLine();
                            elements = currentLine.Split(',');
                            
                            Ticket newTic = new Ticket(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6]);
                            string ticStatus = newTic.status.ToUpper();
                            string ticPrioity = newTic.priority.ToUpper();
                            string ticSubmitter = newTic.submitter.ToUpper();
                            if (ticStatus.Contains(search)) 
                            {
                                Console.WriteLine($"ID: {newTic.idNumber}");
                                Console.WriteLine($"Summary: {newTic.summary}");
                                Console.WriteLine($"Status: {newTic.status}");
                                Console.WriteLine($"Priority: {newTic.priority}");
                                Console.WriteLine($"Submitter: {newTic.submitter}");
                                Console.WriteLine($"Assigned: {newTic.assigned}");
                                Console.WriteLine($"Watching: {newTic.watchers}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (ticPrioity.Contains(search))
                            {
                                //This is essentially copy-pasted code that I couldn't 
                                //refactor without some extra time, so I apologize
                                Console.WriteLine($"ID: {newTic.idNumber}");
                                Console.WriteLine($"Summary: {newTic.summary}");
                                Console.WriteLine($"Status: {newTic.status}");
                                Console.WriteLine($"Priority: {newTic.priority}");
                                Console.WriteLine($"Submitter: {newTic.submitter}");
                                Console.WriteLine($"Assigned: {newTic.assigned}");
                                Console.WriteLine($"Watching: {newTic.watchers}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (ticStatus.Contains(search))
                            {
                                Console.WriteLine($"ID: {newTic.idNumber}");
                                Console.WriteLine($"Summary: {newTic.summary}");
                                Console.WriteLine($"Status: {newTic.status}");
                                Console.WriteLine($"Priority: {newTic.priority}");
                                Console.WriteLine($"Submitter: {newTic.submitter}");
                                Console.WriteLine($"Assigned: {newTic.assigned}");
                                Console.WriteLine($"Watching: {newTic.watchers}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else
                            {
                                Console.WriteLine("No ticket results found\n");
                            }
                        }

                    }
                    using (er)
                    {
                        string headLine = er.ReadLine();
                        while (!er.EndOfStream)
                        {

                            string currentLine = er.ReadLine();
                            elements = currentLine.Split(',');
                            
                            Enhancement enhance = new Enhancement(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7], Convert.ToDouble(elements[8]), elements[9], Convert.ToDouble(elements[10]));
                            string enhanceStatus = enhance.status.ToUpper();
                            string enhancePrioity = enhance.priority.ToUpper();
                            string enhanceSubmitter = enhance.submitter.ToUpper();
                            if (enhanceStatus.Contains(search))
                            {
                                Console.WriteLine($"ID: {enhance.idNumber}");
                                Console.WriteLine($"Summary: {enhance.summary}");
                                Console.WriteLine($"Status: {enhance.status}");
                                Console.WriteLine($"Priority: {enhance.priority}");
                                Console.WriteLine($"Submitter: {enhance.submitter}");
                                Console.WriteLine($"Assigned: {enhance.assigned}");
                                Console.WriteLine($"Watching: {enhance.watchers}");
                                Console.WriteLine($"Software: {enhance.software}");
                                Console.WriteLine($"Cost: {enhance.cost}");
                                Console.WriteLine($"Reason: {enhance.reason}");
                                Console.WriteLine($"Estimate: {enhance.estimate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (enhancePrioity.Contains(search))
                            {
                                Console.WriteLine($"ID: {enhance.idNumber}");
                                Console.WriteLine($"Summary: {enhance.summary}");
                                Console.WriteLine($"Status: {enhance.status}");
                                Console.WriteLine($"Priority: {enhance.priority}");
                                Console.WriteLine($"Submitter: {enhance.submitter}");
                                Console.WriteLine($"Assigned: {enhance.assigned}");
                                Console.WriteLine($"Watching: {enhance.watchers}");
                                Console.WriteLine($"Software: {enhance.software}");
                                Console.WriteLine($"Cost: {enhance.cost}");
                                Console.WriteLine($"Reason: {enhance.reason}");
                                Console.WriteLine($"Estimate: {enhance.estimate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (enhanceSubmitter.Contains(search))
                            {
                                Console.WriteLine($"ID: {enhance.idNumber}");
                                Console.WriteLine($"Summary: {enhance.summary}");
                                Console.WriteLine($"Status: {enhance.status}");
                                Console.WriteLine($"Priority: {enhance.priority}");
                                Console.WriteLine($"Submitter: {enhance.submitter}");
                                Console.WriteLine($"Assigned: {enhance.assigned}");
                                Console.WriteLine($"Watching: {enhance.watchers}");
                                Console.WriteLine($"Software: {enhance.software}");
                                Console.WriteLine($"Cost: {enhance.cost}");
                                Console.WriteLine($"Reason: {enhance.reason}");
                                Console.WriteLine($"Estimate: {enhance.estimate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else
                            {
                                Console.WriteLine("No enhancement results found\n");
                            }
                        }
                    }
                    using (tr)
                    {
                        string headLine = tr.ReadLine();
                        while (!tr.EndOfStream)
                        {
                            string currentLine = tr.ReadLine();
                            elements = currentLine.Split(',');
                            
                            Task tasklet = new Task(Convert.ToInt32(elements[0]), elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7], elements[8]);
                            string taskStatus = tasklet.status.ToUpper();
                            string taskPrioity = tasklet.priority.ToUpper();
                            string taskSubmitter = tasklet.submitter.ToUpper();
                            if (taskStatus.Contains(search))
                            {
                                Console.WriteLine($"ID: {tasklet.idNumber}");
                                Console.WriteLine($"Summary: {tasklet.summary}");
                                Console.WriteLine($"Status: {tasklet.status}");
                                Console.WriteLine($"Priority: {tasklet.priority}");
                                Console.WriteLine($"Submitter: {tasklet.submitter}");
                                Console.WriteLine($"Assigned: {tasklet.assigned}");
                                Console.WriteLine($"Watching: {tasklet.watchers}");
                                Console.WriteLine($"Project Name: {tasklet.projectName}");
                                Console.WriteLine($"Due Date: {tasklet.dueDate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (taskPrioity.Contains(search))
                            {
                                Console.WriteLine($"ID: {tasklet.idNumber}");
                                Console.WriteLine($"Summary: {tasklet.summary}");
                                Console.WriteLine($"Status: {tasklet.status}");
                                Console.WriteLine($"Priority: {tasklet.priority}");
                                Console.WriteLine($"Submitter: {tasklet.submitter}");
                                Console.WriteLine($"Assigned: {tasklet.assigned}");
                                Console.WriteLine($"Watching: {tasklet.watchers}");
                                Console.WriteLine($"Project Name: {tasklet.projectName}");
                                Console.WriteLine($"Due Date: {tasklet.dueDate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else if (taskSubmitter.Contains(search))
                            {
                                Console.WriteLine($"ID: {tasklet.idNumber}");
                                Console.WriteLine($"Summary: {tasklet.summary}");
                                Console.WriteLine($"Status: {tasklet.status}");
                                Console.WriteLine($"Priority: {tasklet.priority}");
                                Console.WriteLine($"Submitter: {tasklet.submitter}");
                                Console.WriteLine($"Assigned: {tasklet.assigned}");
                                Console.WriteLine($"Watching: {tasklet.watchers}");
                                Console.WriteLine($"Project Name: {tasklet.projectName}");
                                Console.WriteLine($"Due Date: {tasklet.dueDate}");
                                Console.WriteLine();
                                matchCount++;
                            }
                            else
                            {
                                Console.WriteLine("No task results found\n");
                            }
                        }
                    }
                    Console.WriteLine($"Total results found: {matchCount}");
                    }        
                            
                    
                    
                
            }
            while (outerMenu == "1" || outerMenu == "2" || outerMenu == "3");
            
        }
    }
}

