namespace InterestingToKnow
{
    public class UsingWeakReference
    {
        // This object doenst hold a real reference to an item on the heap
        // So it wont get garbage collected
        static WeakReference data; 
        public static void Run()
        {
            object result = GetData();
            // GC.Collect(); Uncommenting this line will make data.Target null
            result = GetData();
        }
        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            //If garbage collector has runned, the Target will be null
            //Because it holds the reference to the object on the heap
            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }
    }
}