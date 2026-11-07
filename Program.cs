using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_5
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Dictionary<string, string> students = new Dictionary<string, string>();

            students.Add("0123456789", "John Smith");
            students.Add("9876543210", "Maria Ivanova");
            students.Add("1234509876", "Georgi Petrov");

            PrintStudents(students);

            Console.WriteLine("\nВъведете факултетен номер за търсене: ");
            string key = Console.ReadLine();

            if (students.TryGetValue(key, out string name))
                Console.WriteLine("Намерено: \"{0}\" - \"{1}\"", key, name);
            else
                Console.WriteLine("Няма запис с този ключ.");


            Console.Write("\nВъведете име за търсене: ");
            string value = Console.ReadLine();
            bool found = false;
            foreach(KeyValuePair<string,string> student in students)
            {
                if(student.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Намерено: \"{0}\" - \"{1}\"",
                        student.Key, student.Value);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Няма запис с това име.");


            Console.Write("\nВъведете факултетен номер за премахване: ");
            key = Console.ReadLine();

            if (students.Remove(key))
                Console.WriteLine("Записът е премахнат.");
            else
                Console.WriteLine("Няма запис с този ключ.");


            Console.Write("\nВъведете име за премахване: ");
            value = Console.ReadLine();

            List<string> keysToRemove = new List<string>();

            foreach (KeyValuePair<string, string> student in students)
            {
                if (student.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
                    keysToRemove.Add(student.Key);
            }
            foreach (string studentKey in keysToRemove)
                students.Remove(studentKey);

            if (keysToRemove.Count > 0)
                Console.WriteLine("Премахнати записи: {0}", keysToRemove.Count);
            else
                Console.WriteLine("Няма запис с това име.");


            Console.Write("\nВъведете факултетен номер за промяна: ");
            key = Console.ReadLine();

            if (students.ContainsKey(key))
            {
                Console.Write("Въведете новото име: ");
                string newName = Console.ReadLine();

                students[key] = newName;
                Console.WriteLine("Името е променено.");
            }
            else
            {
                Console.WriteLine("Няма запис с този ключ.");
            }


            Console.WriteLine("\nКрайно съдържание на колекцията:");
            PrintStudents(students);
        }

        static void PrintStudents(Dictionary<string,string> students)
        {
            Console.WriteLine("\nДанни в колекцията:");

            foreach(KeyValuePair<string,string> student in students)
            {
                Console.WriteLine("\"{0}\" - \"{1}\"", student.Key, student.Value);
            }
        }
    }
}