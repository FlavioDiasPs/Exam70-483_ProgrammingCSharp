using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreads.Tasks
{
    public static class UsingParallel
    {
        public static void Measure_For_ForEach_Performance()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Parallel.For(0, 10, i => { Console.WriteLine($"Parallel FOR: {i}"); });
            Console.WriteLine(timer.ElapsedMilliseconds);

            timer.Restart();
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i => { Console.WriteLine($"Parallel FOREACH: {i}"); });
            Console.WriteLine(timer.ElapsedMilliseconds);

            timer.Restart();
            for (int i = 0; i <= 10; i++) { Console.WriteLine($"FOR NORMAL: {i}"); };
            Console.WriteLine(timer.ElapsedMilliseconds);

        }
    }
}
