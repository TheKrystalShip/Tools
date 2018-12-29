using System.Threading.Tasks;

using TheKrystalShip.Tools.Reporting.Models;

namespace TheKrystalShip.Tools.Reporting
{
    public interface IReporter
    {
        Task ReportAsync<T>(T report) where T : class, IReport;
    }
}
