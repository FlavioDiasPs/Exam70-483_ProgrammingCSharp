using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public MyCustomAttribute(string description)
        {
            Description = description;
        }
        public string Description { get; set; }
    }

    [MyCustom("My class description")]
    public static class UsingMyCustomAttribute
    {
        [MyCustom("My method description")]
        public static void DoSomething()
        {
            //this is a reflection use
            var myClassCustomAttr = (MyCustomAttribute)Attribute.GetCustomAttribute
            (
                typeof(UsingMyCustomAttribute),
                typeof(MyCustomAttribute)
            );

            //this is a reflection use
            var myMethodCustomAttr = (MyCustomAttribute)Attribute.GetCustomAttribute
            (
                typeof(UsingMyCustomAttribute).GetMethod("DoSomething"), 
                typeof(MyCustomAttribute)
            );

            Console.WriteLine(myClassCustomAttr.Description);
            myClassCustomAttr.Description = "Changed class description";
            Console.WriteLine(myClassCustomAttr.Description);

            Console.WriteLine(myMethodCustomAttr.Description);
            myMethodCustomAttr.Description = "Changed method description";
            Console.WriteLine(myMethodCustomAttr.Description);
        }
    }
}