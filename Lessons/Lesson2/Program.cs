using System;
using System.IO;

namespace Lesson2
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

            DirectoryInfo di = new DirectoryInfo("Data");
            if (di.Exists)
                di.Delete(true);
            di.Create();
            StreamWriter sw = File.CreateText("Data\\money.txt");

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
            }

            sw.WriteLine("Your income: " + debitSum);

            sw.WriteLine("Your expense: " + creditSum);

            int balance = debitSum - creditSum;

            sw.WriteLine("Your balance: " + balance.ToString());

            if (balance >= 0)
            {
                sw.WriteLine("Congratulations! You are in the black.");
            }
            else
            {
                sw.WriteLine("Alas, you have debts!");
            }
            sw.Close();
        }
    }
}
