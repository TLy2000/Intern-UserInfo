using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PersonsInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Person.GetName();
            //converts to array to display names out
            string users = string.Join(", ", names);
            Console.WriteLine($"Names: {users}");
            string fileName = @"C:\Temp\names.txt";
            AppendTo.AppendToFile(names, fileName);
            AppendTo.ReadFile(fileName);
        }      
    }
    class AppendTo
    {
        public static void AppendToFile(List<string> names, string fileName)
        {
            try
            {
                File.AppendAllLines(fileName, new[] { "Names: " + string.Join(" ", names) });
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        public static void ReadFile(string fileName) 
        {
            // Write file contents on console.     
            using (StreamReader sr = File.OpenText(fileName))
            {
                string lines = String.Empty;
                while ((lines = sr.ReadLine()) != null)
                {
                    Console.WriteLine(lines);
                }
            }

        }
    }
    class Person
    {
        public static List<string> GetName()
        {
            // variables to hold user input
            string firstName, lastName, prompt;
            List<string> nameList = new List<string>();
            // prompt user to input, they can continue to input names so long as they don't terminate
            do
            {
                Console.Write("Enter a first name: ");
                firstName = Console.ReadLine();
                Console.Write("Enter a last name: ");
                lastName = Console.ReadLine();
                Console.Write("Do you want to add another name? Y/N ");
                prompt = Console.ReadLine();
                string fullName = firstName + " " + lastName;

                // appends names to namelist
                nameList.Add(fullName);
            } while (prompt != "n" && prompt != "N");

            return nameList;
        }
    }
}
