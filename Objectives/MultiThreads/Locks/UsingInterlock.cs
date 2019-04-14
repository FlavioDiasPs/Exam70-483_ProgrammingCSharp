using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreads.Locks
{
    // Making operations atomic is the job of the Interlocked class that can be found in the System.Threading namespace. When using the Interlocked.Increment and Interlocked.Decrement,
    // you create an atomic operation
    public class UsingInterlock
    {
        public static void InterlockExample()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });

            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);


            up.Wait();
            Console.WriteLine(n);

            //This code retrieves the current value and immediately sets it to the new value in the same
            // operation. It returns the previous value before changing it. 
            if (Interlocked.Exchange(ref n, 1) == 0) { Console.WriteLine("Exchanged: It was 0, now it is 1"); }

            // This makes sure that comparing the value and exchanging it for a new one is an atomic
            // operation. This way, no other thread can change the value between comparing and exchanging it.
            if (Interlocked.CompareExchange(ref n, 2, 1) == 1) { Console.WriteLine($"ComparedExchanged: It was 1 now it is {n}"); }
        }
    }
}
