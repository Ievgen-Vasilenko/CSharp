using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();
            ContactManager cm = new ContactManager();
            try {
                cm.ReadFromFile(filePath);
            }
            catch(BusinessLogicExeption ex)
            {
                Console.WriteLine(ex.BusinessLogicMessage);
            }
            
            Console.WriteLine("Entries:");
            foreach(ContactEntry ce in cm.Entries)
            {
                Console.WriteLine(ce.ToString());
            }

            Console.WriteLine();
            Console.WriteLine(cm.Log);
            Console.ReadKey();
        }
    }
}
