using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace Dz12
{
    class Program
    {
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }
        static async Task<long> CalculateFactorialAsync(int number)
        {
            return number <= 1 ? 1 : number * await CalculateFactorialAsync(number - 1);
        }
        static int CalculateSquare(int number)
        {
            return (number * number);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Реализации трех потоков, каждый из которых выводит числа от 1 до 10 ");

            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintNumbers);
            Thread thread3 = new Thread(PrintNumbers);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(200);

            Console.WriteLine("\n\nЗадание 2");
            Console.WriteLine("Программа вычисляет факториал асинхронно, возведение в квадрат синхронно");

            Console.Write("\nВведите число: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                int square = CalculateSquare(number);
                Console.WriteLine($"\nКвадрат числа {number} = {square}");

                Thread.Sleep(8000);

                Task<long> factorial = Task.Run(() => CalculateFactorialAsync(number));
                Console.WriteLine($"\nФакториал числа {number} = {factorial.Result}");
            }

            Console.WriteLine("\nЗадание 3");
            Console.WriteLine("Программа получает объект и должна вернуть имена всех методов");

            Type myType = typeof(Refl);

            Console.WriteLine("\nМетоды: ");
            foreach (MethodInfo method in myType.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
