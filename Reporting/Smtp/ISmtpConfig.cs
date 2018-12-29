using System.Net;
using System.Net.Mail;

namespace TheKrystalShip.Tools.Reporting
{
    public interface ISmtpConfig
    {
        NetworkCredential Credential { get; set; }
        MailAddress Destination { get; set; }
        string Host { get; set; }
        MailAddress Origin { get; set; }
        int Port { get; set; }
        string XslFile { get; set; }
    }
}
