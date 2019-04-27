using System;

namespace EventsDelegateLambda
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
            //var del = UsingDelegates.GiveAccess("flavio").DynamicInvoke(2, 4) ;

            #endregion

            #region Lambda + Events + ExpressionTrees

            //UsingLambda.LambdaToDelegate();
            // UsingLambda.LambdaWithAction();
            // UsingLambda.LambdaWithFunc();

            //UsingEvents.RunRaise();

            UsingExpressionTree.RunExpressionTree();
            #endregion

            Console.WriteLine("Got There!");
            Console.Read();

        }
    }
}
