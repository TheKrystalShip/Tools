using System;
using System.Collections.Generic;

namespace TheKrystalShip.Tools.Reporting.Models
{
    /// <summary>
    /// Default implementation of IReport interface
    /// </summary>
    public class Report : IReport
    {
        public Guid Guid { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public List<IReport> InnerReports { get; set; } = new List<IReport>();

        /// <summary>
        /// Default constructor, necessary for serialization
        /// </summary>
        public Report()
        {

        }

        /// <summary>
        /// Automatic binding from Exception object
        /// </summary>
        /// <param name="exception">Exception</param>
        public Report(Exception exception)
        {
            Guid = Guid.NewGuid();
            FileName = string.Format("{0:YYYY-MM-DD HH-mm-ss}.xml", DateTime.Now);
            ErrorMessage = exception.Message;
            StackTrace = exception.StackTrace;

            if (exception.InnerException != null)
            {
                InnerReports.Add(new Report(exception.InnerException));
            }
        }
    }
}
