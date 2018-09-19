using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ImplementingThreads_1_1.ThreadClass
{
    //The thread pool automatically manages the amount of threads it needs to keep around.
    //When it is first created, it starts out empty.
    //As a request comes in, it creates additional threads to handle those requests.As long as it can finish an operation before a new one comes in,no new threads have to be created.If new threads are no longer in use after some time, the thread pool can kill those threads so they no longer use any resources.

    public class UsingThreadPool
    {
        public static void PoolIt()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });           
        }
    }
}
