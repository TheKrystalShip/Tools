using System;

namespace TheKrystalShip.Tools.Reporting
{
    public static class SmtpServiceFactory
    {
        public static ISmtpService Create(Action<ISmtpServiceBuilder> action)
        {
            ISmtpServiceBuilder builder = new SmtpServiceBuilder();
            action(builder);
            return builder.Build();
        }
    }
}
