using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Events
{
    // The lambda function has no specific name as the methods in Listing 1-75 have. 
    // Because of this, lambda functions are called anonymous functions.
    // You also don’t have to specify a return type explicitly. The compiler infers this automatically from your lambda. 

    public static class UsingLambda
    {
        private delegate void Calculate(int x, int y);
        public static void LambdaToDelegate()
        {
            Calculate calc = (x, y) => Console.WriteLine($"{x + y}");
            calc += (x, y) =>
            {
                Console.WriteLine($"Lambda receive x: {x} and y: {y} from called delegate");
            };

            calc(5, 9);
        }
    }
}
