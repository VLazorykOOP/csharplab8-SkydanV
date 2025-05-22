using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Оберіть завдання:");
        Console.WriteLine("1 - Заміна координат вектора");
        Console.WriteLine("2 - Видалення ідентифікаторів");
        Console.WriteLine("3 - Пошук слів по найбільшій кількості");
        Console.WriteLine("4 - Пропозиція");
        Console.WriteLine("5 - Операції з директоріями");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new Lab8T1().Run();
                break;
            case "2":
                await new Lab8T2().Run(); 
                break;
            case "3":
                new Lab8T3().Run();
                break;
            case "4":
                new Lab8T4().Run();
                break;
            case "5":
                new Lab8T5().Run();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }

        Console.WriteLine("\nНатисни будь-яку клавішу, щоб вийти...");
        Console.ReadKey();
    }
}
