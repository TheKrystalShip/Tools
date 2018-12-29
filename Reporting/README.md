# TheKrystalShip.Tools.Reporting

This library serves to transform caught exceptions into XML reports, save them locally and send them via email, with the possibility of using a XSL file to transform the generated XML into a propper emial body.

# Usage

## Report model setup

You'll have to create an implementation if the `IReport` inteface provided under `TheKrystalShip.Tools.Reporting.Models` namespace.

This is because the `Reporter` expects a generic implementation of `IReport`.

> An existing, yet basic, implementation is already provided with the library under the same namespace.

Example class implementing `IReport`

```cs
public class ReportExample : IReport
{
    public Guid Guid { get; set; }
    public string FileName { get; set; }
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
    public string Path { get; set; }
    public List<IReport> InnerReports { get; set; } = new List<IReport>();

    // IMPORTANT: Explicit default constructor is required for serialization process
    public ReportTest()
    {

    }

    // Other constructors can be created as desired
    public ReportTest(Exception exception)
    {
        Guid = Guid.NewGuid();
        FileName = string.Format("{0:YYYY-MM-DD HH-mm-ss}.xml", DateTime.Now);
        ErrorMessage = exception.Message;
        StackTrace = exception.StackTrace;

        if (exception.InnerException != null)
        {
            InnerReports.Add(new ReportTest(exception.InnerException));
        }
    }
}
```

## Reporter setup

For the XML generation, an instance of `IReporter` is required, one can be easly configured using the provided
`ReportedBuilder` and/or `ReporterFactory`.

Example using `ReporterFactory`

```cs
// Using builder
_reporter = new ReporterBuilder()
    .SetOutputPath("Test")
    // .SetSmtpService(_smtpService)
    .Build();

// Using factory
_reporter = ReporterFactory.Create(builder => {
    builder.SetOutputFolder("Test");
    // builder.SetSmtpService(_smtpService);
});
```

## SmtpService setup

There's also the options to send these generated XML reports via email. For that, an instance of `ISmtpService` is requiered.

Much like the `Reporter`, there's also a `SmtpServiceBuilder` and a `SmtpServiceFactory` that can be used to configure one.


```cs
// Using builder
_smtpService = new SmtpServiceBuilder()
    .SetEmailAddresses("origin@test.com", "destination@test.com")
    .SetHostAndPort("smtp.test.com", 424)
    .SetCredentials("username", "password")
    .Build();

// Using factory
_smtpService = SmtpServiceFactory.Create(builder => {
    builder.SetEmailAddresses("test@test.com", "test@test.com");
    builder.SetHostAndPort("smtp.gmail.com", 587);
    builder.SetCredentials("username", "password");
    builder.SetXslFile("test.xsl");
});
```

After which, the created instance can be set during the creation of the `Reporter` using the provided methods.

> If an instance of `SmtpService` is provided to the `Reporter`, email sending is enabled from that point on (Disabled by default).

```cs
// Using builder
_reporter = ReporterFactory.Create(builder => {
    builder.SetOutputFolder("Test");
    builder.SetSmtpService(_smtpService);
});

// Using factory
_reporter = new ReporterBuilder()
    .SetOutputPath("Test")
    .SetSmtpService(_smtpService)
    .Build();
```

Or create both at the same time

```cs
_reporter = ReporterFactory.Create(builder => {
    builder.SetOutputFolder("Test");
    builder.SetSmtpService(smtp => { // SmtpServiceBuilder
        smtp.Origin = new MailAddress("origin@test.com");
        smtp.Destination = new MailAddress("destination@test.com");
        // ...
    });
});
```

## Reporting exceptions

With the `Reporter` instance configured and (optional) `SmtpService`, it's time to put it to use.

```cs
try
{
    // Some code with possible exception throwing
}
catch (Exception exception)
{
    await _reporter.ReportAsync(new ReportTest(exception));
}
```

This will generate an `.xml` file under the specified folder, containing the serialized information from the `ReportTest` type. If `SmtpService` was also configured, an email will be sent with the generated file attached.
