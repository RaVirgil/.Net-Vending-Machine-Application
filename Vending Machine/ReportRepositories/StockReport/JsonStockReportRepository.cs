using iQuest.Business.Models;
using iQuest.Business.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportRepositories.StockReport
{
    public class JsonStockReportRepository : JsonReportRepositoryBase, IStockReportRepository
    {
        public void GenerateReport(IEnumerable<ShelfColumn> shelfColumns)
        {
            if (shelfColumns is null)
                throw new ArgumentNullException(nameof(shelfColumns));

            CreateFolder();

            List<ProductReportItem> reportProducts = shelfColumns
                .Select(x => new ProductReportItem { Name = x.Product.Name, Quantity = x.Product.Quantity })
                .ToList();

            WriteToFile(reportProducts, "Stock");
        }

        [JsonObject("Product")]
        internal class ProductReportItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
}