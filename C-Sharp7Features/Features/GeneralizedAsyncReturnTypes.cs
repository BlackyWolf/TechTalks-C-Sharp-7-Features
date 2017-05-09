using System;
using System.Diagnostics;
using System.Threading.Tasks;
using C_Sharp7Features.Interfaces;

namespace C_Sharp7Features.Features
{
    public class GeneralizedAsyncReturnTypes : IRun
    {
        public void Run()
        {
            var clock = new Stopwatch();

            clock.Start();
            var check1 = RegularTask(true).Result;
            clock.Stop();
            Console.WriteLine($"Time lapsed: {clock.ElapsedMilliseconds}");
            clock.Reset();

            clock.Start();
            var check2 = RegularTask(false).Result;
            clock.Stop();
            Console.WriteLine($"Time lapsed: {clock.ElapsedMilliseconds}");
            clock.Reset();

            clock.Start();
            var check3 = ValueTask(true).Result;
            clock.Stop();
            Console.WriteLine($"Time lapsed: {clock.ElapsedMilliseconds}");
            clock.Reset();

            clock.Start();
            var check4 = ValueTask(false).Result;
            clock.Stop();
            Console.WriteLine($"Time lapsed: {clock.ElapsedMilliseconds}");
            clock.Reset();
        }

        private async Task<int> RegularTask(bool useTask)
        {
            if (useTask) return await Task.Run(() => 1);
            
            return 0;
        }

        private async ValueTask<int> ValueTask(bool useTask)
        {
            if (useTask) return await Task.Run(() => 1);

            return 0;
        }
    }
}