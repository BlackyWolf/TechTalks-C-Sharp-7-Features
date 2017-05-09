using System;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Features
{
    public class Deconstruction : IRun
    {
        public void Run()
        {
            // 1. Tuple deconstruction
            (int age, string lastName) = NameAndAge();

            Console.WriteLine($"{age}, {lastName}");

            // 2. Var deconstruction
            var (anInt, aName) = NameAndAge();
            
            Console.WriteLine($"{anInt}, {aName}");

            // 3. Preexisting variables
            int number;
            string name;

            (number, name) = NameAndAge();
            
            Console.WriteLine($"{number}, {name}");

            // 4. Type Deconstruction
            var nameType = new Name
            {
                FirstName = "Mike",
                MiddleName = "John",
                LastName = "Bold"
            };

            var (it, might, be) = nameType;
            
            Console.WriteLine($"{it} - {might} - {be}");
            
            var (yes, _, maybe) = new Name
            {
                FirstName = "Mike",
                MiddleName = "John",
                LastName = "Bold"
            };

            Console.WriteLine($"{yes} - <<empty>> - {maybe}");
        }

        private (int age, string lastName) NameAndAge()
        {
            return (700, "Wolf");
        }

        private class Name
        {
            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            public int NumberOfNames = 3;

            private bool isAlive = false;

            public void Deconstruct(out string FirstName, out int NumberOfNames, out bool IsAlive)
            {
                FirstName = this.FirstName;
                NumberOfNames = this.NumberOfNames;
                IsAlive = isAlive;
            }
        }
    }
}