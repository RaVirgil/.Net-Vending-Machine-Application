using iQuest.Business.Models;
using System;
using System.Collections.Generic;

namespace iQuest.Business.Reports
{
    public interface IVolumeReportRepository
    {
        void GenerateReport(DateTime start, DateTime end, IEnumerable<Sale> shelfColumns);
    }
}