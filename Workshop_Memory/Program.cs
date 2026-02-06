using System;
using System.Threading;

namespace Workshop_Memory
{
    class Program
    {
        private delegate int AdditionDelegate(int v1, int v2);
        private delegate int SquareDelegate(int v);

        private static int methode(int v1, int v2)
        {
            return v1 + v2;
        }

        private static void RunExercise1()
        {
            AdditionDelegate del = methode;
            int result = del(12, 30);

            Console.WriteLine($"Resultat: {result}");
        }

        private static void RunExercise2a()
        {
            SquareDelegate d = x =>
            {
                int res = x * x;
                Console.WriteLine($"The square of {x} is {res}");
                return res;
            };

            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                int j = i; // capture the loop value for the closure
                threads[j] = new Thread(() => d(j));
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        static void Main(string[] args)
        {
            RunExercise1();
            RunExercise2a();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
