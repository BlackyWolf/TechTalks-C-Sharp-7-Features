using System;
using C_Sharp7Features.Interfaces;
using C_Sharp7Features.Models;
using Newtonsoft.Json;

namespace C_Sharp7Features.Features
{
    public class PatternMatching : IRun
    {
        const string name = "Um";

        public void Run()
        {
            var n = new Fake { Id = 1, Name = "Helpless" };
            Fake l = null;
            var i = default(Fake);

            // 1. Pattern matching against a null constant
            Pattern(null, 1);
            // 2. Pattern matching against a string constant with the same value
            Pattern("Um", 2);
            // 3. Pattern matching against a string constant with a different value
            Pattern("Um...", 3);
            // 4. Pattern matching againt type Fake with a null value
            Pattern(l, 4);
            // 5. Pattern matching against type Fake
            Pattern(n, 5);
            // 6. Pattern matching against null, using default(Type)
            Pattern(i, 6);

            Console.WriteLine("\n\n");

            // 7. Pattern matching subtypes using a switch statement
            var circle = new Circle { Radius = 4.5 };
            var rectangle = new Rectangle { Height = 5, Length = 8 };
            var square = new Square { Height = 5, Length = 5 };
            var trapezoid = new Trapezoid { NumberOfSides = 7 };

            GetShapeData(circle);
            GetShapeData(rectangle);
            GetShapeData(square);
            GetShapeData(trapezoid);
        }

        private void Pattern(object something, int order)
        {

            if (something is Fake thing)
            {
                Console.WriteLine($"{order} - 'something' is also of type 'Fake'");
            }

            if (something is null)
            {
                Console.WriteLine($"{order} - 'something' is 'null'");
                
                return;
            }

            if (something is name)
            {
                Console.WriteLine($"{order} - 'something' is the same as 'name'");

                return;
            }

            if (something is Fake stuff)
            {
                Console.WriteLine($"{order} - 'n' is of type 'Fake' with Id {stuff.Id}");
            }
        }

        private void GetShapeData(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine($"Circle: radius({circle.Radius})");
                    break;
                case Rectangle rectangle when (rectangle.Height > 10):
                    Console.WriteLine($"Rectangle: height({rectangle.Height}) > 10, length({rectangle.Length})");
                    break;
                case Rectangle rectangle:
                    Console.WriteLine($"Rectangle: height({rectangle.Height}), length({rectangle.Length})");
                    break;
                default:
                    Console.WriteLine("No known shape");
                    break;
            }
        }

        private class Fake
        {
            public int Id { get; set; }

            public string Name { get; set; } 
        }
    }
}