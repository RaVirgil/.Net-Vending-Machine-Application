using iQuest.Business.Models;
using iQuest.Business.Reports;
using System;
using System.Collections.Generic;

namespace ReportRepositories.SalesReport
{
    public class JsonSalesReportRepository : JsonReportRepositoryBase, ISalesReportRepository
    {
        public void GenerateReport(IEnumerable<Sale> sales)
        {
            if (sales is null)
                throw new ArgumentNullException(nameof(sales));

            CreateFolder();

            WriteToFile(sales, "Sales");
        }
    }
}