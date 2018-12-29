using System;
using System.IO;
using System.Threading.Tasks;

using TheKrystalShip.Tools.Reporting.Internal;
using TheKrystalShip.Tools.Reporting.Models;

namespace TheKrystalShip.Tools.Reporting
{
    public class Reporter : IReporter
    {
        private readonly IReporterConfig _config;

        public Reporter(IReporterConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Generates a log file based on a model implementing the IReport interface with
        /// the option to also send it via email.
        /// </summary>
        /// <typeparam name="T">Implementation of IReport interface</typeparam>
        /// <param name="report">Model implementing IReport interface</param>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task ReportAsync<T>(T report) where T : class, IReport
        {
            report.Path = Path.Combine(_config.OutputFolderPath, report.FileName);

            XmlHandler.Serialize(report);

            if (!_config.SendEmail)
                return;

            await _config.EmailService.SendEmailAsync(report);
        }
    }
}
