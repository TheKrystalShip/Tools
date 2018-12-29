using System.Net;
using System.Net.Mail;

namespace TheKrystalShip.Tools.Reporting
{
    public class SmtpConfig : ISmtpConfig
    {
        /// <summary>
        /// Email server hostname
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Email server port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// SMTP service credentials
        /// </summary>
        public NetworkCredential Credential { get; set; }

        /// <summary>
        /// Address from which the email is sent from
        /// </summary>
        public MailAddress Origin { get; set; }

        /// <summary>
        /// Address to which the email is sent to
        /// </summary>
        public MailAddress Destination { get; set; }

        /// <summary>
        /// (Optional) XSLT Transformation file for the email body
        /// </summary>
        public string XslFile { get; set; }
    }
}
