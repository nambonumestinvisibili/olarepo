using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
namespace Lista4DawidHolewa
{
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {

        }
        
        public static Singleton Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public class ThreadSingleton
    {
        private ThreadSingleton() { }

        private static ThreadLocal<ThreadSingleton> _instances = new ThreadLocal<ThreadSingleton>(() => new ThreadSingleton());

        public static ThreadSingleton Instance
        {
            get { return _instances.Value; }
        }
    }

    public class Singleton5sec
    {
        private Singleton5sec () { }

        private static Singleton5sec _instance;
        private static System.Timers.Timer _timer;
        public static Singleton5sec Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton5sec();
            }
            SetTimer();
            return _instance;
        }

        private static void SetTimer()
        {
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs elapsedEventArgs)
        {
            _instance = new Singleton5sec();
        }
    }
}
