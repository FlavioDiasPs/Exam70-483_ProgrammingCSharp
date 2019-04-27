using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessModifiersAndInterfaces
{
    internal class Program
    {       

        static void Main(string[] args)
        {
            #region Modifiers

            // new AccessModifiers().MyDerivedMethod();
            // new AccessModifiers().MyInternalMethod();
            // var a = new AccessModifiers()._internalField;
            // Console.WriteLine($"Outside A: {a}");
            // Console.WriteLine("You should check what is happening in here");

            #endregion

            #region Interfaces

            // ExplicitInterfacesImplementation.TryAccessIt();
            // InterfacesHierarchy.TryToCastIt();

            // Base1 b = new Base1();
            // b.Execute();
            // b = new Derived1();
            // b.Execute();

            // Derived1 d = new Derived1();
            // d.Execute();
            

            #endregion

            Console.WriteLine("done");
            Console.Read();
        }
    }
}
