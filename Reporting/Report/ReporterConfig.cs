using System.IO;

namespace TheKrystalShip.Tools.Reporting
{
    public class ReporterConfig : IReporterConfig
    {
        /// <summary>
        /// Directory to write file to.
        /// </summary>
        public string OutputFolderPath { get; set; }

        /// <summary>
        /// Name of the file that will be written to disk
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Bool value to send email after generating error log file. If set to true, must specify email
        /// service details.
        /// </summary>
        public bool SendEmail { get; set; }

        /// <summary>
        /// Use EmailServiceBuilder to create a EmailService instance
        /// </summary>
        public ISmtpService EmailService { get; set; }

        /// <summary>
        /// XSLT file to transform IReport model into a valid Email body html (Only necessary if SendEmail = true).
        /// </summary>
        public string XSLFile { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReporterConfig()
        {
            OutputFolderPath = Path.Combine("Reporter");
            SendEmail = false;
        }
    }
}
