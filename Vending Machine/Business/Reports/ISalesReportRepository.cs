using iQuest.Business.Models;
using System.Collections.Generic;

namespace iQuest.Business.Reports
{
    public interface ISalesReportRepository
    {
        void GenerateReport(IEnumerable<Sale> shelfColumns);
    }
}