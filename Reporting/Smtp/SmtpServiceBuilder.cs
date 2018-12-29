using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace TheKrystalShip.Tools.Reporting
{
    public class SmtpServiceBuilder : ISmtpServiceBuilder
    {
        private ISmtpConfig _config;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SmtpServiceBuilder()
        {
            _config = new SmtpConfig();
        }

        public SmtpServiceBuilder(ISmtpConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Specify the username and password for the SMTP service.
        /// </summary>
        /// <param name="username">Email service username used to login</param>
        /// <param name="password">Email service password used to login</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public ISmtpServiceBuilder SetCredentials(string username, string password)
        {
            if (username is null)
                throw new ArgumentNullException(nameof(username));

            if (password is null)
                throw new ArgumentNullException(nameof(password));

            _config.Credential = new NetworkCredential(username, password);

            return this;
        }

        /// <summary>
        /// Set the credentials for the SMTP service
        /// </summary>
        /// <param name="credential">NetworkCredential instance</param>
        /// <returns></returns>
        public ISmtpServiceBuilder SetCredentials(NetworkCredential credential)
        {
            if (credential is null)
                throw new ArgumentNullException(nameof(credential));

            _config.Credential = credential;

            return this;
        }

        /// <summary>
        /// Specify the sender and reciever email addresses
        /// </summary>
        /// <param name="origin">Who sends the email</param>
        /// <param name="destination">Who to send the email to</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <returns></returns>
        public ISmtpServiceBuilder SetEmailAddresses(string origin, string destination)
        {
            if (origin is null)
                throw new ArgumentNullException(nameof(origin));

            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            _config.Origin = new MailAddress(origin);
            _config.Destination = new MailAddress(destination);

            return this;
        }

        /// <summary>
        /// Specify the sender and reciever email addresses
        /// </summary>
        /// <param name="origin">Who sends the email</param>
        /// <param name="destination">Who to send the email to</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public ISmtpServiceBuilder SetEmailAddresses(MailAddress origin, MailAddress destination)
        {
            if (origin is null)
                throw new ArgumentNullException(nameof(origin));

            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            _config.Origin = origin;
            _config.Destination = destination;

            return this;
        }

        /// <summary>
        /// Only use this method if in .SetEmailProvider() you specified EmailProvider.Manual
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public ISmtpServiceBuilder SetHostAndPort(string host, int port)
        {
            if (host is null)
                throw new ArgumentNullException(nameof(host));

            if (port is 0)
                throw new ArgumentException("Invalid port value");

            _config.Host = host;
            _config.Port = port;

            return this;
        }

        /// <summary>
        /// Set a XSLT file to transform the XML file into a HTML Email body
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns></returns>
        public ISmtpServiceBuilder SetXslFile(string path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));

            _config.XslFile = path;

            return this;
        }

        /// <summary>
        /// Build a EmailService instance
        /// </summary>
        /// <returns>A EmailService instance</returns>
        public ISmtpService Build()
        {
            return new SmtpService(_config);
        }
    }
}
