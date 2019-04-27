using System;

namespace AttributesAndReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // UsingMyCustomAttribute.DoSomething();
            UsingReflection.GetPluginByAssemblyName(@"ReflectionAssemblies\Attributes.dll");

            Console.WriteLine("Done");
            Console.Read();            
        }
    }
}
