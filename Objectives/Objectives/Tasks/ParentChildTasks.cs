using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingThreads_1_1.Tasks
{
    public static class ParentChildTasks
    {
        public static void RunTasksWithParent_Default_DenyChildAttach()
        {
            //TaskCreationOptions.DenyChildAttach has been defined as default for Task.Run() at C# 5.0

            var parentTask = Task.Run(() =>
            {
                var results = new Int32[3];
                Console.WriteLine("started parent task");

                new Task(() => { results[0] = 3; Console.WriteLine("0"); }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => { results[1] = 4; Console.WriteLine("1"); }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => { results[2] = 5; Console.WriteLine("2"); }, TaskCreationOptions.AttachedToParent).Start();

                Console.WriteLine("finished parent task");
             
                return results;
            });

            Console.WriteLine("Other stuff");

            var finalTask = parentTask.ContinueWith
            (
                task =>
                {
                    Console.WriteLine("Continuing with");
                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                }
            );

            finalTask.Wait();
        }

        public static void RunTasksWithParent_Simplified()
        {
            Task<Int32[]> parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("started parent task");

                var results = new Int32[3];
                var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => { results[0] = 3; Console.WriteLine("0"); });
                tf.StartNew(() => { results[1] = 4; Console.WriteLine("1"); });
                tf.StartNew(() => { results[2] = 5; Console.WriteLine("2"); });

                Console.WriteLine("finished parent task");

                return results;
            }, TaskCreationOptions.None);

            Console.WriteLine("Other stuff");

            var finalTask = parent.ContinueWith
            (
                parentTask =>
                {
                    Console.WriteLine("Continuing with");

                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                }
            );
            finalTask.Wait();
        }
    }
}
