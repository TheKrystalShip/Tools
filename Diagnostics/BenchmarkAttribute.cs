using System;
using System.Diagnostics;

namespace TheKrystalShip.Tools.Diagnostics
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchmarkAttribute : Attribute, IDisposable
    {
        private readonly Stopwatch _stopwatch;

        public BenchmarkAttribute()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {_stopwatch.Elapsed.ToString()}");
        }
    }
}
