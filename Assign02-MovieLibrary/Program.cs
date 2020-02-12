using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assign02_MovieLibrary
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string file = "jeff.csv";
            string outerMenu;


            string[] elements = new string[3];
            int idCounter = 0;
            
            do
            {
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Write");
                outerMenu = Console.ReadLine();
                if (outerMenu == "1")
                {
                    try
                    {
                        StreamReader sr = new StreamReader(file);
                        string firstLine = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {

                            string currentLine = sr.ReadLine();
                            elements = currentLine.Split(',');
                            Console.WriteLine($"ID: {elements[0]}");


                            switch (elements.Length)
                            {
                                case 3:
                                    Console.WriteLine($"Title: {elements[1]}");
                                    Console.WriteLine($"Genres: {elements[2]}");
                                    break;
                                case 4:
                                    Console.WriteLine($"Title: {elements[1]}{elements[2]}");
                                    Console.WriteLine($"Genres: {elements[3]}");
                                    break;
                                case 5:
                                    Console.WriteLine($"Title: {elements[1]}{elements[2]}{elements[3]}");
                                    Console.WriteLine($"Genres: {elements[4]}");
                                    break;
                                default:
                                    Console.WriteLine("Details not found");
                                    Logger.Error("Some film entries were not loaded");
                                    break;
                            }

                            Console.WriteLine();
                            idCounter = Convert.ToInt32(elements[0]) + 1;
                        }
                        sr.Close();
                    
                    }
                    catch (FileNotFoundException ef) { Console.WriteLine($"File Not Found, Exception: {ef}"); }

                }
                else
                {
                    string innerMenu = "Y";
                    StreamWriter sw = new StreamWriter(file, append: true);
                    for (int inner = 0; inner < 5; inner++)
                    {
                        if (idCounter == 0)
                        {
                            Console.WriteLine("No film entries found. Please read in entries.");
                            break;
                        }
                        else
                        {
                            string title;
                            string genres;
                            Console.WriteLine("Enter the Title");

                            title = Console.ReadLine();
                            sw.Write($"{idCounter},{title},");
                            idCounter++;
                            Console.WriteLine("Enter the genres");
                            genres = Console.ReadLine();
                            sw.Write($"{genres}\n");
                            Logger.Info("Film entry added");
                            Console.WriteLine("Add New Film? (Y/N)");
                            innerMenu = Console.ReadLine();
                            if (innerMenu == "N") { break; }
                        }

                    }


                    sw.Close();

                }
            }
            while (outerMenu == "1" || outerMenu == "2");
        }
    }
}
