using System;

namespace UsingCodeDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingCodeDOM.GenerateCode.GenerateHelloWorld();


            Console.WriteLine("Check the HelloWorld.cs fila generated!");
            Console.Read();
        }
    }
}
