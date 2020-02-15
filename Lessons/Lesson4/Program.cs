using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter vehicle type:");
            Console.WriteLine("VAZ - to select VAZ 2107");
            Console.WriteLine("Lamborgini - to select Labmborgini Gallardo");
            Console.WriteLine("Ferrari - to select Ferrari Testarossa");

            string type = Console.ReadLine();

            Car choosenCar = GetCarByType(type);
            Console.WriteLine();
            Console.WriteLine("You choosed:");
            Console.WriteLine(choosenCar.ToString());

            Console.WriteLine("Lets GO!:");
            choosenCar.Drive();
            Console.WriteLine(choosenCar.ToString());

            if(choosenCar is ITurbo)
            {
                Console.WriteLine("Turbocharged car");
                ((Lamborgini)choosenCar).Turbo();
            }

            Console.ReadKey();
        }

        static Car GetCarByType(string type)
        {
            switch (type)
            {
                case "VAZ":
                    return new Vaz();
                case "Lamborgini":
                    return new Lamborgini();
                case "Ferrari":
                    return new Ferrari();
                default:
                    return null;
            }
        }
    }
}
