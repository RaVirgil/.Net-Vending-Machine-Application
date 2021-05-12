using iQuest.Business.Models;
using System.Collections.Generic;

namespace iQuest.Business.Reports
{
    public interface IStockReportRepository
    {
        void GenerateReport(IEnumerable<ShelfColumn> shelfColumns);
    }
}