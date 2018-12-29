using System;

namespace TheKrystalShip.Tools.Reporting
{
    public interface IReporterBuilder
    {
        IReporterBuilder SetOutputFolder(string folderPath);
        IReporterBuilder SetSmtpService(Action<ISmtpConfig> action);
        IReporterBuilder SetSmtpService(ISmtpService smtpService);
        IReporter Build();
    }
}
