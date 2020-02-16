﻿using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            ContactManager cm = new ContactManager(filePath);
            Console.WriteLine("Entries:");
            foreach(ContactEntry ce in cm.Entries)
            {
                Console.WriteLine(ce.ToString());
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
