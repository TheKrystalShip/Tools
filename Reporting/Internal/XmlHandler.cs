﻿using System.IO;
using System.Xml.Serialization;
using System.Xml.Xsl;

using TheKrystalShip.Tools.Reporting.Models;

namespace TheKrystalShip.Tools.Reporting.Internal
{
    internal static class XmlHandler
    {
        private static XmlSerializer _serializer;

        public static void Serialize<T>(T report) where T : class, IReport
        {
            _serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(report.Path))
            {
                _serializer.Serialize(writer, report);
            }
        }

        public static T Deserialize<T>(string path) where T : class
        {
            object toReturn;
            _serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(path))
            {
                toReturn = _serializer.Deserialize(reader);
            }
            return (T)toReturn;
        }

        public static string Transform(string xmlFileUri, string xsltFileUri)
        {
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(xsltFileUri);

            using (StringWriter results = new StringWriter())
            {
                xsl.Transform(xmlFileUri, null, results);
                return results.ToString();
            }
        }
    }
}
