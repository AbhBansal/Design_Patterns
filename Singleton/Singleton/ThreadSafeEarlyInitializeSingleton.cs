using System;

namespace Singleton
{
    class ThreadSafeEarlyInitializeSingleton
    {
        static private int counter = 0;
        private static ThreadSafeEarlyInitializeSingleton instance = new ThreadSafeEarlyInitializeSingleton();

        private ThreadSafeEarlyInitializeSingleton()
        {
            counter++;
            Console.WriteLine("Early Object Created " + counter);
        }

        public static ThreadSafeEarlyInitializeSingleton getInstance
        {
            get
            {
                return instance;
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
