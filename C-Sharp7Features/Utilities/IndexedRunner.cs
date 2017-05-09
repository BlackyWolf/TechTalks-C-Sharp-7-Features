using System;
using System.Collections.Generic;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Utilities
{
    public class IndexRunner : IRun<int>
    {
        private readonly IList<IRun> runners;

        public IndexRunner(params IRun[] runners)
        {
            this.runners = runners ?? throw new ArgumentNullException(nameof(runners));
        }

        public void Run(int index)
        {
            Console.Clear();

            runners[index]?.Run();
        }
    }
}