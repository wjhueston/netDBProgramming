using System;
using System.IO;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            string file = "data.txt";

            if (resp == "1")
            {
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                string[] dateParts = new string[2];
                DateTime dateConversion;
                string[] hourParts = new string[7];
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    

                        while (!sr.EndOfStream)
                        {
                            string currentLine = sr.ReadLine();
                            dateParts = currentLine.Split(',');
                            dateConversion = Convert.ToDateTime(dateParts[0]);
                            string hourSet = dateParts[1];
                            
                            Console.WriteLine($"Week of {dateConversion:MMMM dd, yyyy}");
                            Console.WriteLine("Su Mo Tu We Tr Fr Sa  Avg  Tot");
                            Console.WriteLine("-- -- -- -- -- -- --  ---  ---");
                            int weekTotals = 0;
                            for(int i = 0; i<7; i++)
                        {
                            hourParts = hourSet.Split('|');
                            Console.Write($"{hourParts[i], 2} ");
                            weekTotals += Convert.ToInt32(hourParts[i]);
                        }
                        Console.WriteLine($" {weekTotals/7, 3} {weekTotals, 4}");
                        Console.WriteLine();
                        Console.WriteLine();
                            

                        }
                    
                    sr.Close();
                }
            }
        }
    }
}
