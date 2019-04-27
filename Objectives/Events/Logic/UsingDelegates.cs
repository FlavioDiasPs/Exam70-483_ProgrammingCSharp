using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Events
{
    // A delegate is a type that defines a method signature
    public static class UsingDelegates
    {
        private delegate void Calculate(int x, int y);
        private static void Add(int x, int y) { Console.WriteLine($"{x + y}"); }
        private static void Multiply(int x, int y) { Console.WriteLine($"{x * y}"); }
        public static void UseDelegate()
        {
            Calculate calc = Add;
            calc(3, 4); // Displays 7

            calc = Multiply;
            calc(3, 4); // Displays 12
        }
        public static void MulticastDelegate()
        {
            Calculate calc = Add;
            calc += Multiply;
            calc(3, 4); // Displays 7 and 12
        }

        private delegate IEnumerable<string> CovarianceDel();
        private static List<string> MethodList() { Console.WriteLine("Covariance MethodList!"); return null; }
        private static Collection<string> MethodCollection() { Console.WriteLine("Covariance MethodCollection!"); return null; }
        public static void CovarianceDelegate()
        {
            //List and Collection inherits from IEnumerable, so they for sure can execute what an IEnumerable would
            CovarianceDel del;
            del = MethodList;
            del = MethodCollection;
            del();
        }

        private delegate void ContravarianceDel(List<string> value);
        private static void MethodListContravariance(IEnumerable<string> value) { Console.WriteLine("Contravariance!"); }
        public static void ContravarianceDelegate()
        {
            ContravarianceDel del;
            del = MethodListContravariance;
            del(new List<string>());
        }

        private static void OnlyAuthorizedCanExecute(int a, int b) { Console.WriteLine($"Authorized, Received: {a}, {b}"); }
        public static Delegate GiveAccess(string name)
        {
            if (name == "flavio")
            {
                return OnlyAuthorizedCanExecute;                                            
            }
            else
            {
                return null;
            }
        }


    }
}