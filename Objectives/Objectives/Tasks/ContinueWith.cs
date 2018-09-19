using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingThreads_1_1.Tasks
{
    //There is no built-in way to know when the operation has finished and what the return value is.    
    //This is why the.NET Framework introduces the concept of a Task, which is an object that represents some work that should be done.
    //The Task can tell you if the work is completed and if the operation returns a result, the Task gives you the result.

    //ContinueWith, execute as soon as the task ends
    public class ContinueWith
    {
        public static void RunContinueWith()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine(t.Result); // Displays 84
        }

        public static void RunContinueWithOptions()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
    }
}
