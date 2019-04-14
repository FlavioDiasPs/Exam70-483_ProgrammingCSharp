using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreads.ThreadClass
{
    public class AttributeThreadStatic
    {
        //A thread has its own call stack that stores all the methods that are executed. 
        //Local variables are stored on the call stack and are private to the thread.

        //A thread can also have its own data that’s not a local variable.
        //By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field

        [ThreadStatic] //Remove  it, and see the maximum value of _field get to 20. 
        private static int _field;
        public static void StaticAttributeThreads()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread A: {_field}", _field);
                    Thread.Sleep(1);
                }
            }).Start();


            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread B: {_field}");
                    Thread.Sleep(1);
                }
            }).Start();

            Console.ReadKey();
        }    
    }
}
