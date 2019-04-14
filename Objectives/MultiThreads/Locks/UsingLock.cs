using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreads.Locks
{
    // x++; operation is not atomic. It consists of both a read and a write that happen at different moments. 
    // This is why access to the data you’re working with needs to be synchronized, 
    // so you can reliably predict how your data is affected.

    // One feature the C# language offers to synchronize data is the lock operator, 
    // which is some syntactic sugar that the compiler translates in a call to System.Thread.Monitor
    public class UsingLock
    {

        //The lock makes sure that the code will wait until the lock is off
        //By doing this, the full read and write operations will be done without outside changes
        public static void NoLockExample()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });

            for (int i = 0; i < 1000000; i++)
                n--;

            up.Wait();
            Console.WriteLine(n); //unknow result
        }            
        public static void LockExample()
        {
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        n++;
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    n--;
                }
            }

            up.Wait(); //result is always 0 
            Console.WriteLine(n);
        }
        public static void DeadLockExample()
        {
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {                    
                    lock (lockB)
                    {                        
                        Console.WriteLine("Locked A and B");
                        Thread.Sleep(5000);   
                    }
                }
            });
            
            Thread.Sleep(1000);
            lock (lockB)
            {
                lock (lockA)
                {                    
                    Console.WriteLine("Loucked B and A");
                }
            }

            up.Wait();
        }   
    }
}
