using System;

namespace AccessModifiersAndInterfaces
{
    //Explicit interface implementation is necessary: 
    //when a class implements two interfaces that contain duplicate method signatures 
    //but wants a different implementation for both. 

    // When you have an instance of Implementation, you can’t access MyMethod. 
    // But when you cast Implementation to IInterfaceA, you have access to MyMethod. 
    // In such a way, explicit interface implementation can be used to hide members of a class to outside users.
    public class ExplicitInterfacesImplementation
    {
        interface ILeft
        {
            void Move();
        }
        interface IRight
        {
            void Move();
        }
        class MoveableOject : ILeft, IRight
        {
            void ILeft.Move() { }
            void IRight.Move() { Console.WriteLine("Right move!"); }
        }

        public static void TryAccessIt()
        {
            var obj = new MoveableOject();
            ((IRight)obj).Move();
        }
    }

    public class InterfacesHierarchy
    {
        interface IAnimal
        {
            void Move();
        }
        class Dog : IAnimal
        {
            public void Move() { }
            public void Bark() { }
        }
        public static void TryToCastIt()
        {
            IAnimal animal = new Dog();
            ((Dog)animal).Bark();
        }
    }

    class Base1
    {
        public void Execute() { Console.WriteLine("Base.Execute"); }
    }
    class Derived1 : Base1
    {
        public new void Execute() { Console.WriteLine("Derived.Execute"); }
    }  
}