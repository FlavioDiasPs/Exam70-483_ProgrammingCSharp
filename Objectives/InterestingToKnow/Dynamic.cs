using System;
using System.Dynamic;

namespace InterestingToKnow
{
    class SampleObject : DynamicObject
    {
        public override string ToString()
        {
            Console.WriteLine("Deu override!");

            return "";
        }        
    }

    static class AnotherSampleObject
    {    
        public static dynamic SomeProperty { get; set; } = new ExpandoObject();
    }

    public class DynamicStuff
    {
        public void Run()
        {
            new SampleObject().ToString();            
            AnotherSampleObject.SomeProperty.Type = "Dynamic expandable calculator";
            AnotherSampleObject.SomeProperty.Add = new Func<int, int, int>((firstDigit, secondDigit) => { return firstDigit + secondDigit; });
            AnotherSampleObject.SomeProperty.Subtract = new Func<int, int, int>((firstDigit, secondDigit) => { return firstDigit - secondDigit; });
            AnotherSampleObject.SomeProperty.Multiply = new Func<int, int, int>((firstDigit, secondDigit) => { return firstDigit * secondDigit; });
            AnotherSampleObject.SomeProperty.Divide = new Func<int, int, double>((firstDigit, secondDigit) => { return firstDigit / secondDigit; });
            AnotherSampleObject.SomeProperty.Describe = new Action(() => Console.WriteLine("This is a dynamic calculator."));
        }
    }
}