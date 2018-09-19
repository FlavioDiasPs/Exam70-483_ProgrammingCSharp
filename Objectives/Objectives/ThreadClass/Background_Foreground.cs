using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ImplementingThreads_1_1.ThreadClass
{
    public class Background_Foreground
    {
        //Foreground threads can be used to keep an application alive. 
        //Only when all foreground threads end does the common language runtime (CLR) shut down your application. 
        //Background threads are then terminated.

        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }
        public static void NonThreadMethod()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();
        }
    }
}

