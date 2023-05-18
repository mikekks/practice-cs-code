using System;

namespace chap
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("print Async");
            });

            Console.WriteLine("print Sync");
            t1.Wait();

            Console.WriteLine("Main end");
        }
    }
}