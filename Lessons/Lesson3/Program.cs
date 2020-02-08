using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            MoneyEntry me = new MoneyEntry();

            Console.WriteLine("Hello!");

            Console.Write("Enter amount: ");

            string amount = Console.ReadLine();

            Console.Write("Enter date: ");

            string date = Console.ReadLine();

            me.InitWithString(amount, date);

            Console.WriteLine("Your record:");

            Console.WriteLine(me.ToString());

            if (me.isDebit)
                Console.WriteLine("You have a new income.");
            else
                Console.WriteLine("You have a new expense.");
        }
    }
}
