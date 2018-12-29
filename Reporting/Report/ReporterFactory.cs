using System;

namespace TheKrystalShip.Tools.Reporting
{
    public static class ReporterFactory
    {
        public static IReporter Create(Action<IReporterBuilder> action)
        {
            IReporterBuilder builder = new ReporterBuilder();
            action(builder);
            return builder.Build();
        }
    }
}
