using System;

namespace Singleton
{
    class ThreadSafeLazyInitializeSingleton
    {
        static private int counter = 0;
        private static ThreadSafeLazyInitializeSingleton instance = null;
        private static readonly object obj = new object();

        private ThreadSafeLazyInitializeSingleton()
        {
            counter++;
            Console.WriteLine("Lazy Object Created " + counter);
        }

        public static ThreadSafeLazyInitializeSingleton getInstance
        {
            get
            {
                //Double checked locking
                if(instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new ThreadSafeLazyInitializeSingleton();
                    }
                }
                return instance;
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
