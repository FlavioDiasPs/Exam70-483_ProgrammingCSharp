using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InterestingToKnow
{
    class UsingIComparable : IComparable
    {
        public UsingIComparable()
        {

        }
        public UsingIComparable(int a)
        {
            Number = a;
        }
        public int Number { get; set; }

        public int CompareTo(object obj)
        {
            if (obj.ToString().All(char.IsNumber))
            {
                return Number.CompareTo(obj);
            }
            else
            {
                return -1;
            }
        }
    }
    class UsingIEnumerable : IEnumerable<RandomObject>
    {
        RandomObject[] _RandomObjects;
        public UsingIEnumerable(RandomObject[] RandomObjects)
        {
            _RandomObjects = RandomObjects;
        }
        public IEnumerator<RandomObject> GetEnumerator()
        {
            for (int i = 0; i < _RandomObjects.Length; i++)
            {
                yield return _RandomObjects[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyIComparable
    {
        public static void RunComparissom()
        {
            var comparable = new UsingIComparable();
            comparable.Number = 1;

            Console.WriteLine(comparable.CompareTo(1));
            Console.WriteLine(comparable.CompareTo(2));
        }
        public static void RunLinqSort()
        {
            var UsingIComparables = new List<UsingIComparable>()
            {
                new UsingIComparable(2),
                new UsingIComparable(1),
                new UsingIComparable(3),
                new UsingIComparable(4)
            };

            UsingIComparables = UsingIComparables.OrderByDescending(u => u.Number).ToList();
            UsingIComparables.All(u => { Console.WriteLine(u.Number.ToString()); return true; });

            UsingIComparables.Sort();
            UsingIComparables.All(u => { Console.WriteLine(u.Number.ToString()); return true; });
        }
    }
    public class MyIEnumerable
    {
        public static void RunEnumerable()
        {
            var randomObjs = new UsingIEnumerable(new RandomObject[]
            {
                new RandomObject(1),
                new RandomObject(3),
                new RandomObject(5),
                new RandomObject(7),
                new RandomObject(4)
            });

            Console.WriteLine("Explicit Enumerator");
            var enumerator = randomObjs.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.MyNumber);
            }
            enumerator.Dispose();

            Console.WriteLine("Foreach");
            foreach (var item in randomObjs)
            {
                Console.WriteLine(item.MyNumber);
            }
        }
    }
    public class MyIDisposable
    {
        public static void RunDisposable()
        {
            var uw = new UnmangedWrapper();
            uw.Dispose();
        }
    }

    class UnmangedWrapper : IDisposable
    {
        public FileStream Stream { get; private set; }
        public UnmangedWrapper()
        {
            this.Stream = File.Open("teste.txt", FileMode.Create);
        }
        ~UnmangedWrapper()
        {
            //False because stream already have a finnalizer
            //So we dont need to call it twice, let the garbage collector deal with it
            Dispose(false);
        }
        public void Close()
        {
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            //We want to make sure that the garbage collector 
            //wil remove this class reference from his of objects to be freed
            //because we are mannually removing them from memory
            System.GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }
}