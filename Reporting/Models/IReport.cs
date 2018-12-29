using System;
using System.Collections.Generic;

namespace TheKrystalShip.Tools.Reporting.Models
{
    /// <summary>
    /// Any implementation of this class needs to have one parameterless constructor
    /// in order for it to be serialized by the Reporter.
    /// </summary>
    public interface IReport
    {
        Guid Guid { get; set; }
        string FileName { get; set; }
        string ErrorMessage { get; set; }
        string StackTrace { get; set; }
        string Path { get; set; }
        List<IReport> InnerReports { get; set; }
    }
}
