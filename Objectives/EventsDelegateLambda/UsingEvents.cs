using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// A popular design pattern (a reusable solution for a recurring problem) in application development 
// is that of publish-subscribe. You can subscribe to an event and then you are notified
// when the publisher of the event raises a new event. This is used to establish loose coupling
// between components in an application.

namespace EventsDelegateLambda
{
    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
    
    public class Pub
    {
        private event EventHandler<MyArgs> _OnChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (_OnChange)
                {
                    _OnChange += value;
                }
            }
            remove
            {
                lock (_OnChange)
                {
                    _OnChange -= value;
                }
            }
        }
        public void Raise()
        {
            _OnChange(this, new MyArgs(42));
        }
    }

    public static class UsingEvents
    {
        public static void RunRaise()
        {
            var p = new Pub();
            p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);
            p.Raise();
        }
    }
}
