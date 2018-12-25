using System;
using System.Diagnostics;

namespace TheKrystalShip.Tools.Diagnostics
{
    public class Benchmark : IDisposable
    {
        private readonly Stopwatch _stopwatch;

        public Benchmark()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {_stopwatch.Elapsed.ToString()}");
        }

        public static Benchmark CreateNew()
        {
            return new Benchmark();
        }
    }
}
