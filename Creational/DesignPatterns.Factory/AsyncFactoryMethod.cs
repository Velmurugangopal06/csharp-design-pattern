using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class StopWatch
    {
        private int _timerInMins;
        private StopWatch(int timerInMins)
        {
            _timerInMins = timerInMins;
        }

        private static async Task<StopWatch> InitAsync(int timerInMins)
        {
            await Task.Delay(1000);
            return new StopWatch(timerInMins);
        }

        public static async Task<StopWatch> CreateInstance(int timerInMins)
        {
            return await InitAsync(timerInMins);
        }

        public override string ToString()
        {
            return $"{nameof(_timerInMins)} is set to {_timerInMins} Minutes";
        }
    }
    public class AsyncFactoryMethod
    {
        public static async Task Main()
        {
            var timerInMins = 3;
            var sw = await StopWatch.CreateInstance(timerInMins);
            Console.WriteLine($"{sw}");
        }
    }
}
