using System;
using System.Threading;
using System.Threading.Tasks;
using MultiThreads.Locks;

namespace MultiThreads
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

            #region Code related to Locks
            // UsingLock.NoLockExample();
            // UsingLock.LockExample();
            // UsingLock.DeadLockExample();

            //UsingVolatile.VolatileExample();
            UsingInterlock.InterlockExample();

            #endregion


            Console.WriteLine("GotThere!");
            Console.Read();
        }
    }
}
