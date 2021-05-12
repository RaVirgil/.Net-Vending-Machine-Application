using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ReportRepositories
{
    public class XmlReportRepositoryBase
    {
        internal void CreateFolder()
        {
            if (!Directory.Exists("./GeneratedReports"))
                Directory.CreateDirectory("./GeneratedReports");
        }

        internal string CreateFilePath(string xmlType)
        {
            return $"{Directory.GetCurrentDirectory()}/GeneratedReports/{xmlType} Report-" +
               $"{DateTime.Now:yyyy MM dd HHmmss}.xml";
        }

        internal void WriteToFile<T>(T reportItem, string reportType)
        {
            string path = CreateFilePath(reportType);

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(reportItem.GetType());
                using (var xmlWriter = XmlWriter.Create(streamWriter, new XmlWriterSettings { Indent = true, IndentChars = "\t" }))
                {
                    serializer.Serialize(xmlWriter, reportItem);
                }
            }
        }
    }
}