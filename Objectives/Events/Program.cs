using System;

namespace Events
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region Delegates

            // UsingDelegates.UseDelegate();
            // UsingDelegates.MulticastDelegate();
            // UsingDelegates.CovarianceDelegate();
            // UsingDelegates.ContravarianceDelegate();
            var del = UsingDelegates.GiveAccess("flavio");
            del.DynamicInvoke(2, 4);
            #endregion

            #region Lambda + Events

            //UsingLambda.LambdaToDelegate();
            //UsingEvents.RunRaise();

            #endregion

            Console.WriteLine("Events Got There!");
            Console.Read();

        }
    }
}
