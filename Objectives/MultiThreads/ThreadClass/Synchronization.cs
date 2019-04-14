using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreads.ThreadClass
{
    public class Synchronization
    {

        //Synchronization is the mechanism of ensuring that two threads don’t execute a specific portion of your program at the same time.
        //In the case of a console application, this means that no two threads can write data to the screen at the exact same time.

        private static void ThreadMethod()
        {
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"ThreadMethod: {i}");
                Thread.Sleep(1); //This makes the compiler know when to change to the other threads.
            }
        }

        public static void NonThreadMethod()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(1); //This makes the compiler know when to change to the other threads.
            }

            t.Join(); //This makes the method wait until the end of all threads
        }
    }
}
