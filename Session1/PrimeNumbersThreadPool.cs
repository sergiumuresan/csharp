using System;
using System.Threading;
using System.Collections.Concurrent;

namespace csharp.Session1
{
    public class PrimeNumbersThreadPool
    {
        private const long min = 0;
        private static long max = 2;
        private static readonly ConcurrentQueue<long> primes = new ConcurrentQueue<long>();

        private static void GeneratePrimes(long start, long range)
        {
            var isPrime = true;
            var end = Math.Min(start + range, max);
            var newStart = Math.Max(start + 1, 2);

            Console.WriteLine($"Processing range {newStart} - {end}");

            for (var i = newStart; i <= end; i++)
            {
                for (var j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Enqueue(i);
                }
                isPrime = true;
            }

            Thread.Sleep(0);
        }

        public static void DoWork()
        {
            Console.Write("Threads: ");
            var threadCount = Math.Max(Convert.ToInt32(Console.ReadLine()), 1);

            Console.Write("Max Prime: ");
            max = Math.Max(Convert.ToInt64(Console.ReadLine()), 2);

            var range = Convert.ToInt64(Math.Ceiling(max / (double)threadCount));

            Console.WriteLine($"Range: {range}");

            var start = min;

            var startDate = DateTime.Now;

            var toProcess = threadCount;
            using (var resetEvent = new ManualResetEvent(false))
            {
                for (var i = 0; i < threadCount; i++)
                {
                    var startl = start;
                    ThreadPool.QueueUserWorkItem((s) =>
                    {
                        GeneratePrimes(startl, range);

                        if (Interlocked.Decrement(ref toProcess) == 0)
                        {
                            resetEvent.Set();
                        }

                    });
                    start += range;
                }

                resetEvent.WaitOne();
            }

            var endDate = DateTime.Now.Subtract(startDate);

            Console.Write($"Found {primes.Count} primes in {endDate.TotalSeconds} seconds using {threadCount} threads on a CPU with {Environment.ProcessorCount} cores.");
        }
    }
}
