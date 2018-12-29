using System;
using System.Threading.Tasks;

using TheKrystalShip.Tools.Reporting.Models;

namespace TheKrystalShip.Tools.Reporting
{
    public interface ISmtpService : IDisposable
    {
        Task SendEmailAsync<T>(T report) where T : class, IReport;
    }
}
