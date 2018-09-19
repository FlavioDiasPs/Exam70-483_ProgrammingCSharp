using System;
using System.Threading;

namespace ImplementingThreads_1_1
{
    public class Program
    {       
        public static void Main()
        {
            #region Code related to ThreadClass
            //ThreadClass.Synchronization.NonThreadMethod();
            //ThreadClass.Background_Foreground.NonThreadMethod();
            //ThreadClass.StoppingThreads.NonThreadMethod();
            //ThreadClass.AttributeThreadStatic.StaticAttributeThreads();
            //ThreadClass.UsingThreadPool.PoolIt();
            #endregion

            #region Code related to Tasks
            //Tasks.ContinueWith.RunWithContinueWith();
            Tasks.ContinueWith.RunContinueWithOptions();

            #endregion






            Console.WriteLine("GotThere!");
            Console.ReadKey();
        }

        
    }
}
