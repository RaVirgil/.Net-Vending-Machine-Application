using iQuest.Business.Models;
using iQuest.Business.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ReportRepositories.VolumeReport
{
    public class XmlVolumeReportRepository : XmlReportRepositoryBase, IVolumeReportRepository
    {
        public void GenerateReport(DateTime startTime, DateTime endTime, IEnumerable<Sale> productLogs)
        {
            if (productLogs is null)
                throw new ArgumentNullException(nameof(productLogs));

            CreateFolder();

            List<ProductReportItem> reportProducts = productLogs
                .GroupBy(x => x.ProductName)
                .Select(x => new ProductReportItem { Name = x.Key, Quantity = x.Count() })
                .ToList();

            VolumeReportItem volumeReportItem = new VolumeReportItem
            {
                StartTime = startTime,
                EndTime = endTime,
                Sales = reportProducts
            };

            WriteToFile(volumeReportItem, "Volume");
        }

        public class VolumeReportItem
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public List<ProductReportItem> Sales { get; set; }
        }

        [XmlType(TypeName = "Product")]
        public class ProductReportItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
}