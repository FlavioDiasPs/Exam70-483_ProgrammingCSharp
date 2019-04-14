using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreads.Locks
{
    // This class has a special Write and Read method
    // those methods disable the compiler optimizations so you can force the correct order in your
    // code. Using these methods in the correct order can be quite complex, so .NET offers the
    // volatile keyword that you can apply to a field. You would then change the declaration of your
    // field to this: private static volatile int _flag = 0;
    
    public class UsingVolatile
    {
        // private static int _flag = 0;
        private static volatile int _flag = 0;
        private static int _value = 0;
        public static void VolatileExample()
        {
            Thread1();
            Thread2();
        }
        private static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }
        private static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);            
        }
    }
}
