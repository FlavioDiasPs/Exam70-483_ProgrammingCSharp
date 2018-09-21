using System;
using System.Threading;
using System.Threading.Tasks;

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
            //Tasks.ContinueWith.RunContinueWithOptions();
            //Tasks.ParentChildTasks.RunTasksWithParent_Default_DenyChildAttach();
            //Tasks.ParentChildTasks.RunTasksWithParent_Simplified();
            //Tasks.UsingParallel.Measure_For_ForEach_Performance();
            //Task.Run(() => { Tasks.UsingAyncAwait.RunAsyncOperation().GetAwaiter().GetResult(); });

            
            #endregion



            Console.WriteLine("GotThere!");
            Console.ReadKey();
        }
    }
}
