using iQuest.Business.Models;
using iQuest.Business.Reports;
using System;
using System.Collections.Generic;

namespace ReportRepositories.SalesReport
{
    public class XmlSalesReportRepository : XmlReportRepositoryBase, ISalesReportRepository
    {
        public void GenerateReport(IEnumerable<Sale> productLogs)
        {
            if (productLogs is null)
                throw new ArgumentNullException(nameof(productLogs));

            CreateFolder();

            WriteToFile(productLogs, "Sales");
        }
    }
}