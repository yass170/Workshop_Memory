using System;
using System.Diagnostics;
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
                int j = i; // capture loop value for the closure
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

        private static void RunExercise2b()
        {
            Func<int, int> square = x => x * x;
            int value = 7;
            int result = square(value);

            Console.WriteLine($"Square of {value} is {result}");
        }

        private static void RunExercise3()
        {
            var data = new { Id = 1, Label = "Memo" };
            Console.WriteLine($"Anonymous type -> Id: {data.Id}, Label: {data.Label}");
        }

        private delegate void SimpleDelegate();

        private class A
        {
            public void ma()
            {
                Console.WriteLine("ma");
            }
        }

        private class B
        {
            public void mb()
            {
                Console.WriteLine("mb");
            }
        }

        private static void RunExercise4()
        {
            A a = new A();
            B b = new B();

            SimpleDelegate simple = a.ma;

            SimpleDelegate[] delegates = new SimpleDelegate[2];
            delegates[0] = a.ma;
            delegates[1] = b.mb;

            SimpleDelegate multi = a.ma;
            multi += b.mb;

            a.ma();
            b.mb();

            simple();

            for (int i = 0; i < delegates.Length; i++)
            {
                delegates[i]();
            }

            multi();

            multi -= b.mb;
            multi();
        }

        private static void AllocateLargeArrayOnStack(int size)
        {
            try // Stack
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                Span<int> largeArray = size == 0 ? Span<int>.Empty : stackalloc int[size];

                for (int j = 0; j < 2000; j++)
                {
                    largeArray[0] = 0;

                    for (int i = 1; i < largeArray.Length; i++)
                    {
                        largeArray[i] = largeArray[i - 1];
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"stack : {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"stack allocation not possible: {ex.Message}");
            }
        }

        private static void AllocateLargeArrayOnHeap(int size)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                int[] largeArray = new int[size];

                for (int j = 0; j < 2000; j++)
                {
                    largeArray[0] = 0;

                    for (int i = 1; i < largeArray.Length; i++)
                    {
                        largeArray[i] = largeArray[i - 1];
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Heap : {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"heap allocation not possible: {ex.Message}");
            }
        }

        private static void RunExercise5()
        {
            const int largeSize = 300000;
            AllocateLargeArrayOnHeap(largeSize);
            AllocateLargeArrayOnStack(largeSize);
        }

        private sealed class DatabaseConnection : IDisposable
        {
            private bool isOpen;

            public DatabaseConnection()
            {
                Console.WriteLine("Database connection opened.");
                isOpen = true;
            }

            public void ExecuteQuery(string query)
            {
                if (!isOpen)
                {
                    throw new InvalidOperationException("The connection is closed.");
                }

                Console.WriteLine($"Executing query: {query}");
            }

            public void Close()
            {
                if (isOpen)
                {
                    Console.WriteLine("Database connection closed.");
                    isOpen = false;
                }
            }

            public void Dispose()
            {
                Close();
            }
        }

        private static void RunExercise6()
        {
            try
            {
                using DatabaseConnection connection = new DatabaseConnection();
                connection.ExecuteQuery("SELECT * FROM Users");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }

        static void Main(string[] args)
        {
            RunExercise1();
            RunExercise2a();
            RunExercise2b();
            RunExercise3();
            RunExercise4();
            RunExercise5();
            RunExercise6();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
