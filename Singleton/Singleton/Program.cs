using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Ensure a class only has one instance, and provide a global point of access to it.
 * 
 */


namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadSafeLazyInitialization();
            Console.WriteLine();
            ThreadSafeEarlyInitialization();
            Console.ReadKey();
        }

        private static void ThreadSafeLazyInitialization()
        {
            Console.WriteLine("Lazy Loading");
            Parallel.Invoke(
                () => LazyObject1(),
                () => LazyObject2()
                );
        }

        private static void LazyObject2()
        {
            ThreadSafeLazyInitializeSingleton singletonObj2 = ThreadSafeLazyInitializeSingleton.getInstance;
            singletonObj2.Print("From Lazy Object 2");
        }

        private static void LazyObject1()
        {
            ThreadSafeLazyInitializeSingleton singletonObj1 = ThreadSafeLazyInitializeSingleton.getInstance;
            singletonObj1.Print("From Lazy Object 1");
        }


        private static void ThreadSafeEarlyInitialization()
        {
            Console.WriteLine("Early Loading");
            Parallel.Invoke(
                () => EarlyObject1(),
                () => EarlyObject2()
                );
        }

        private static void EarlyObject2()
        {
            ThreadSafeEarlyInitializeSingleton singletonObj2 = ThreadSafeEarlyInitializeSingleton.getInstance;
            singletonObj2.Print("From Early Object 2");
        }

        private static void EarlyObject1()
        {
            ThreadSafeEarlyInitializeSingleton singletonObj1 = ThreadSafeEarlyInitializeSingleton.getInstance;
            singletonObj1.Print("From Early Object 1");
        }
    }
}
