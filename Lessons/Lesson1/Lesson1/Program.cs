using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string debit = "";
            string credit = "";
            int debitInt = 0;
            int creditInt = 0;
            int debitSum = 0;
            int creditSum = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter income: ");

                debit = Console.ReadLine();

                int.TryParse(debit, out debitInt);

                debitSum += debitInt;

                Console.Write("Enter flow: ");

                credit = Console.ReadLine();

                int.TryParse(credit, out creditInt);

                creditSum += creditInt;

                Console.WriteLine("");
            }

            Console.WriteLine("Your income: " + debitSum);

            Console.WriteLine("Your expense: " + creditSum);

            int balance = debitSum - creditSum;

            Console.WriteLine("Your balance: " + balance.ToString());

            if (balance >= 0)
            {
                Console.WriteLine("Congratulations! You are in the black.");
            }
            else
            {
                Console.WriteLine("Alas, you have debts!");
            }
            Console.ReadKey();
        }
    }
}
