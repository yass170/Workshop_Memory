using System;

namespace Workshop_Memory
{
    class Program
    {
        private delegate int AdditionDelegate(int v1, int v2);

        private static int methode(int v1, int v2)
        {
            return v1 + v2;
        }

        static void Main(string[] args)
        {
            AdditionDelegate del = methode;
            int result = del(12, 30);

            Console.WriteLine($"Resultat: {result}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
