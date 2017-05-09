using System;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Utilities
{
    public class ConstantRunner : IRun<IRun[]>
    {
        public ConstantRunner() => this.name = "No name";

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public void Run(IRun[] runners)
        {
            foreach (IRun runner in runners ?? throw new ArgumentNullException(nameof(runners)))
            {
                Console.Clear();

                runner.Run();

                Console.ReadKey();
            }
        }

        private string name;

        public void SetName(string name) => this.name = name;

        public int Age => 20;


    }
}