using Business.ViewInterfaces;
using iQuest.Business.Models;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using System;
using System.Collections.Generic;

namespace iQuest.Business.UseCases.ReportUseCases
{
    public class SalesReportUseCase : IUseCase
    {
        private readonly ISalesHistoryRepository logsRepository;
        private readonly ISalesReportRepository salesReportRepository;
        private readonly IReportView reportView;

        public SalesReportUseCase(ISalesHistoryRepository logsRepository, ISalesReportRepository salesReportRepository, IReportView reportView)
        {
            this.logsRepository = logsRepository ?? throw new ArgumentNullException(nameof(logsRepository));
            this.salesReportRepository = salesReportRepository ?? throw new ArgumentNullException(nameof(salesReportRepository));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
        }

        public void Execute()
        {
            Tuple<DateTime, DateTime> dateRange = reportView.AskDateTimes();
            DateTime startTime = dateRange.Item1;
            DateTime endTime = dateRange.Item2;

            IEnumerable<Sale> productLogs = logsRepository.GetInDateRange(startTime, endTime);
            salesReportRepository.GenerateReport(productLogs);
        }
    }
}