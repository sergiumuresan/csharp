using csharp.Session1;
using System;
 
namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PrimeNumbers");
           
            PrimeNumbers.DoWork();

            Console.WriteLine("\nPrimeNumbersTask");

            PrimeNumbersTask.DoWork();

            Console.WriteLine("\nPrimeNumbersAsync");

            PrimeNumbersAsync.DoWork();

            Console.WriteLine("\nPrimeNumbersParallel");

            PrimeNumbersParallel.DoWork();

            Console.WriteLine("\nPrimeNumbersThreadPool");

            PrimeNumbersThreadPool.DoWork();

            Console.ReadKey();
        }
    }
}