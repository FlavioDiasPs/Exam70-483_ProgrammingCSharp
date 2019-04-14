using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreads.ThreadClass
{
    //To stop a thread, you can use the Thread.Abort method. 
    //However, because this method is executed by another thread, it can happen at any time. 
    //When it happens, a ThreadAbortException is thrown on the target thread. 
    //This can potentially leave a corrupt state and make your application unusable.
    //A better way to stop a thread is by using a shared variable that both your target and your calling thread can access.

    public class StoppingThreads
    {
        public static void ThreadMethod(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(0);
            }
        }

        public static void NonThreadMethod()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            stopped = true;

            t.Join();
        }
    }
}

   