using System;
using C_Sharp7Features.Features;
using C_Sharp7Features.Interfaces;
using C_Sharp7Features.Utilities;
using static System.Console;

namespace C_Sharp7Features
{
    class Program
    {
        static void Main(string[] args)
        {
            var runners = new IRun[]
            {
                new OutVariables(),
                new PatternMatching(),
                new Tuples(),
                new Deconstruction(),
                new RefReturnsAndLocals(),
                new GeneralizedAsyncReturnTypes()
            };


            Console.WriteLine(20_000_000);

            while (ReadKey().Key != ConsoleKey.Escape)
            {
                Clear();

                //InvokeConstantRunner();
                InvokeIndexedRunner();
            }

            void InvokeConstantRunner()
            {
                Console.WriteLine(20_000_000);

                new ConstantRunner().Run(runners);
            }

            void InvokeIndexedRunner()
            {
                WriteLine("Please choose which feature examples to run: ");
                WriteLine("0. Out Variables");
                WriteLine("1. Pattern Matching");
                WriteLine("2. Tuples");
                WriteLine("3. Deconstruction");
                WriteLine("4. Ref Returns and Locals");
                WriteLine("5. Generalized Async Returns");
                Write(": ");

                int.TryParse(ReadLine(), out int index);

                if (index > -1 && index < runners.Length) new IndexRunner(runners).Run(index);
                else WriteLine("Wrong choice, try again!");
            }
        }
    }
}