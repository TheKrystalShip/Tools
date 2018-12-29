using System;
using System.IO;

namespace TheKrystalShip.Tools.Reporting
{
    public class ReporterBuilder : IReporterBuilder
    {
        private IReporterConfig _config;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReporterBuilder()
        {
            _config = new ReporterConfig();
        }

        public ReporterBuilder(IReporterConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Specify an output directory (Must already exist)
        /// </summary>
        /// <param name="folderPath"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns></returns>
        public IReporterBuilder SetOutputFolder(string folderPath)
        {
            if (folderPath is null)
                throw new ArgumentNullException(nameof(folderPath));

            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException(nameof(folderPath));

            _config.OutputFolderPath = folderPath;

            return this;
        }

        /// <summary>
        /// Configure the SmtpService instance to be used by the Reporter.
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public IReporterBuilder SetSmtpService(Action<ISmtpConfig> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            ISmtpConfig config = new SmtpConfig();
            action(config);

            _config.EmailService = new SmtpServiceBuilder(config).Build();
            _config.SendEmail = true;

            return this;
        }

        /// <summary>
        /// Configure the EmailService instance to be used by the Reporter.
        /// Use the EmailServiceBuilder class to make a EmailService instance.
        /// </summary>
        /// <param name="smtpService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public IReporterBuilder SetSmtpService(ISmtpService smtpService)
        {
            if (smtpService is null)
                throw new ArgumentNullException(nameof(smtpService));

            _config.EmailService = smtpService;
            _config.SendEmail = true;

            return this;
        }

        public IReporter Build()
        {
            return new Reporter(_config);
        }
    }
}
