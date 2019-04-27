using System;
using AttributesAndReflection;

namespace some
{    
    public class MySecondTesteClass : IPlugin
    {
        public string Name => "The name of the second";

        public string Description => "The description of the second";

        private void DoSomething()
        {
            Console.WriteLine("I am doing something from inside the plugin");
        }
    }
}