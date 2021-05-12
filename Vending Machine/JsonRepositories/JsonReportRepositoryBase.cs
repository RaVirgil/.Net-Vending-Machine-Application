using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace JsonRepositories
{
    public class JsonReportRepositoryBase
    {
        internal void CreateFolder()
        {
            if (!Directory.Exists("./GeneratedReports"))
                Directory.CreateDirectory("./GeneratedReports");
        }

        internal string CreateFilePath(string reportType)
        {
            return $"{Directory.GetCurrentDirectory()}/GeneratedReports/{reportType} Report-" +
                 $"{DateTime.Now:yyyy MM dd HHmmss}.json";
        }

        internal void WriteToFile<T>(T reportItem, string reportType)
        {
            string path = CreateFilePath(reportType);

            using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    jsonWriter.Indentation = 4;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, reportItem);
                }
            }
        }
    }
}