using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingMyCustomAttribute.DoSomething();

            Console.Read();
            Console.WriteLine("Done");
        }
    }
}
