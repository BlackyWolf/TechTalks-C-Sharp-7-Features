using System;
using System.Diagnostics;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Features
{
    public class RefReturnsAndLocals : IRun
    {
        public void Run()
        {
            int[,] matrix = new int[100, 300];

            SetMatrix(matrix);

            Console.WriteLine("-- Begin find with out ref");

            Console.WriteLine($"Starting memory: {Process.GetCurrentProcess().WorkingSet64 / 1000 } KB");

            var indices = Find(matrix, x => x == 150);


            Console.WriteLine($"Memory without find by reference: {Process.GetCurrentProcess().WorkingSet64 / 1000} KB");

            ref int value = ref FindByRef(matrix, x => x == 150);
            Console.WriteLine(value);
            value = 34;
            Console.WriteLine(matrix[0, 150]);
            Console.WriteLine(value);

            matrix[indices.i, indices.j] = 11;

            //Console.WriteLine("Value: {0}\nMemory with find by reference: {1} KB", matrix[0, 150], Process.GetCurrentProcess().WorkingSet64 / 1000);
            //Console.WriteLine($"Value: {matrix[0, 150]}\nMemory with find by reference: {Process.GetCurrentProcess().WorkingSet64 / 1000 } KB");
            //Console.WriteLine(matrix[0, 150]);

            ref int item = ref FindByRef(matrix, x => x == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[0, 42]);
        }

        private static (int i, int j) Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1); // Not found
        }

        public static ref int FindByRef(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return ref matrix[i, j];
                    }
                }
            }

            throw new InvalidOperationException("Not found");
        }

        private void SetMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = j;
                }
            }
        }
    }
}