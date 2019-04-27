using System;

namespace AccessModifiersAndInterfaces
{
    //     Access modifier Description
    //     public None; restricted access
    //     internal Limited to the current assembly
    //     protected Limited to the containing class and derived classes
    //     protected internal Limited to the current assembly or derived types
    //     private Limited to the containing type
    public class Base
    {
        private int _privateField = 42;
        protected int _protectedField = 42;
        internal int _internalField = 42;
        private void MyPrivateMethod() { }
        protected void MyProtectedMethod() { }
        internal void MyInternalMethod() { }
    }
    public class Derived : Base
    {
        internal virtual void MyDerivedMethod()
        {
            //_privateField = 41; // Not OK, this will generate a compile error
            _protectedField = 43; // OK, protected fields can be accessed
            _internalField = 43; //same assembly

            //MyPrivateMethod(); // Not OK, this will generate a compile error
            MyProtectedMethod(); // OK, protected methods can be accessed
            MyInternalMethod();
        }
    }
    internal class AccessModifiers : Derived
    {        
        internal override void MyDerivedMethod()
        {
            var a = _internalField; //accessed because of assembly
            var b = _protectedField; //accessed because of derived            

            Console.WriteLine($"a: {a}, b: {b}");
        }
    }
}