namespace TheKrystalShip.Tools.Reporting
{
    public interface IReporterConfig
    {
        ISmtpService EmailService { get; set; }
        string FileName { get; set; }
        string OutputFolderPath { get; set; }
        bool SendEmail { get; set; }
        string XSLFile { get; set; }
    }
}
