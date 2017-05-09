using System;
using System.Globalization;
using System.Linq;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Features
{
    public class Tuples : IRun
    {
        public void Run()
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetNumbers()));



            // 1. Old Tuple syntax
            Tuple<int, string> oldTuple = OldTuple();

            // 2. New syntax, no named variables or deconstruction
            (int, string) someStuff = NameAndAge();

            Console.WriteLine($"{someStuff.Item1}, {someStuff.Item2}");

            // 3. New syntax with named variables, no deconstruction
            (int yearsAlive, string lastName) anObject = NameAndAge();

            Console.WriteLine($"{anObject.lastName}, {anObject.yearsAlive}");

            // 4. New syntax with deconstruction and typed variables
            (int age, string lastName) = NameAndAge();

            Console.WriteLine($"{age}, {lastName}");

            // 5. New syntax with deconstruction and var variables
            (var myAge, var familyName) = NameAndAge();

            Console.WriteLine($"{myAge}, {familyName}");

            // 6. New syntax with alternative named variables, no deconstruction
            var stuff = AgeAndName();

            Console.WriteLine($"{stuff.name} / {stuff.age}");

            // 7. Playing with the new tuple syntax,
            //    a tuple within a tuple within a tuple
            (string exclamation, (Thing thing, (int id, int[] numbers) numerics)[] tuples) = MultiTuples();

            foreach ((Thing thing, (int id, int[] numbers) numerics) valueTuple in tuples)
            {
                Console.Write($"{exclamation}! {valueTuple.numerics.id} - ");
                
                foreach (int number in valueTuple.numerics.numbers)
                {
                    Console.Write($"{number}, ");
                }

                Console.WriteLine($"{valueTuple.thing.Is}");
            }

            // 8. Playing with the new tuple syntax,
            //    tuples as parameters using params :P
            Console.WriteLine($"\n{TupleAsParameter((1, "yus"))}");
            Console.WriteLine($"{TupleAsParameter((0, "yus"))}");
            Console.WriteLine($"{TupleAsParameter((2, "            "))}");

            Console.WriteLine($"\n{TupleAsParams((1, "um"), (2, "nou"))}");
            Console.WriteLine($"{TupleAsParams((1, "um"), (0, "nou"))}");
            Console.WriteLine($"{TupleAsParams((1, "   "), (2, "nou"))}");
        }

        private Tuple<int, string> OldTuple()
        {
            return new Tuple<int, string>(1, "Yay!");
        }

        private (int age, string lastName) NameAndAge()
        {
            return (700, "Wolf");
        }

        private (int age, string name) AgeAndName()
        {
            return (age: 700, name: "Wolf");
        }

        private (string exclamation, (Thing thing, (int id, int[] numbers) numerics)[] tuples) MultiTuples()
        {
            return ("Oh no!", new (Thing thing, (int id, int[] numbers) numerics)[]
            {
                (new Thing { Is = "A thing" }, (1, new [] { 2, 3, 4, 5 })),
                (new Thing { Is = "Another thing" }, (10, new [] { 6, 7, 8, 9 })),
            });
        }

        private bool TupleAsParameter((int Number, string Value) tuple)
        {
            return tuple.Number > 0 && !string.IsNullOrWhiteSpace(tuple.Value);
        }

        private bool TupleAsParams(params (int number, string value)[] tuples)
        {
            return tuples.All(
                valueTuple => valueTuple.number > 0 &&
                              !string.IsNullOrWhiteSpace(valueTuple.value)
            );
        }

        private (int, int, int, int, int, int, int, int, int) LimitedTuples()
        {
            return (1, 2, 3, 4, 5, 6, 7, 8, 9);
        }

        private class Thing
        {
            public string Is { get; set; }
        }

        private (int, int, int, int, int, int, int, int, int, int, int, int) GetNumbers()
        {
            return (1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
        }
    }
}