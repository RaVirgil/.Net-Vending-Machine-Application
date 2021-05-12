using iQuest.Business.Models;
using iQuest.Business.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ReportRepositories.StockReport
{
    public class XmlStockReportRepository : XmlReportRepositoryBase, IStockReportRepository
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

        [XmlType(TypeName = "Product")]
        public class ProductReportItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
}