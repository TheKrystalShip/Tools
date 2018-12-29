using System;
using System.Net.Mail;
using System.Threading.Tasks;

using TheKrystalShip.Tools.Reporting.Internal;
using TheKrystalShip.Tools.Reporting.Models;

namespace TheKrystalShip.Tools.Reporting
{
    /// <summary>
    /// Used to send email containing IReport file
    /// </summary>
    public class SmtpService : ISmtpService
    {
        private readonly SmtpClient _client;
        private readonly ISmtpConfig _config;

        public SmtpService(ISmtpConfig config)
        {
            _config = config;

            _client = new SmtpClient
            {
                Host = _config.Host,
                Port = _config.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = _config.Credential
            };
        }

        /// <summary>
        /// Send email with an error report
        /// </summary>
        /// <param name="report">Implementation of IReport interface</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <returns></returns>
        public async Task SendEmailAsync<T>(T report) where T : class, IReport
        {
            MailMessage email = new MailMessage(_config.Origin, _config.Destination)
            {
                Subject = $"{DateTime.Now} - Error Report"
            };

            if (_config.XslFile != null)
            {
                email.IsBodyHtml = true;
                email.Body = XmlHandler.Transform(report.Path, _config.XslFile);
            }
            else
            {
                email.IsBodyHtml = false;
                email.Body = "An error report was generated, see attached file";
            }

            email.Attachments.Add(new Attachment(report.Path));

            await _client.SendMailAsync(email);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
