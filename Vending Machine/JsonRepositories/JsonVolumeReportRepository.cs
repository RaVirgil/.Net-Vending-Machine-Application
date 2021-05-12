using iQuest.Business.Models;
using iQuest.Business.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonRepositories.VolumeReport
{
    public class JsonVolumeReportRepository : JsonReportRepositoryBase, IVolumeReportRepository
    {
        public void GenerateReport(DateTime startTime, DateTime endTime, IEnumerable<Sale> productLogs)
        {
            if (productLogs is null)
                throw new ArgumentNullException(nameof(productLogs));

            CreateFolder();

            VolumeReportItem volumeReportItem = CreateVolumeReportData(startTime, endTime, productLogs);

            WriteToFile(volumeReportItem, "Volume");
        }

        private VolumeReportItem CreateVolumeReportData(DateTime startTime, DateTime endTime, IEnumerable<Sale> productLogs)
        {
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
            return volumeReportItem;
        }

        [JsonObject("Sales")]
        internal class VolumeReportItem
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public List<ProductReportItem> Sales { get; set; }
        }

        [JsonObject("Product")]
        internal class ProductReportItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
}