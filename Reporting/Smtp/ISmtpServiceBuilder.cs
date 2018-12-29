using System.Net;
using System.Net.Mail;

namespace TheKrystalShip.Tools.Reporting
{
    public interface ISmtpServiceBuilder
    {
        ISmtpServiceBuilder SetCredentials(string username, string password);
        ISmtpServiceBuilder SetCredentials(NetworkCredential credential);
        ISmtpServiceBuilder SetEmailAddresses(MailAddress origin, MailAddress destination);
        ISmtpServiceBuilder SetEmailAddresses(string origin, string destination);
        ISmtpServiceBuilder SetHostAndPort(string host, int port);
        ISmtpServiceBuilder SetXslFile(string path);
        ISmtpService Build();
    }
}
