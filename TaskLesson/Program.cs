using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            MakeLongWork().Start();
            Console.WriteLine("UI поток закончил");
            Console.ReadLine();
        }

        private static Task MakeLongWork()
        {
            return new Task(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
        }
    }
}
