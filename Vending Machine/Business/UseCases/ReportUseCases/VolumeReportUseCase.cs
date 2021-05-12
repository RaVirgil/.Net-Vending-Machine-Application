using Business.ViewInterfaces;
using iQuest.Business.Models;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using System;
using System.Collections.Generic;

namespace iQuest.Business.UseCases.ReportUseCases
{
    public class VolumeReportUseCase : IUseCase
    {
        private readonly ISalesHistoryRepository logsRepository;
        private readonly IVolumeReportRepository volumeReportRepository;
        private readonly IReportView reportView;

        public VolumeReportUseCase(ISalesHistoryRepository logsRepository, IVolumeReportRepository volumeReportRepository, IReportView reportView)
        {
            this.logsRepository = logsRepository ?? throw new ArgumentNullException(nameof(logsRepository));
            this.volumeReportRepository = volumeReportRepository ?? throw new ArgumentNullException(nameof(volumeReportRepository));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
        }

        public void Execute()
        {
            Tuple<DateTime, DateTime> dateRange = reportView.AskDateTimes();
            DateTime startTime = dateRange.Item1;
            DateTime endTime = dateRange.Item2;

            IEnumerable<Sale> productLogs = logsRepository.GetInDateRange(startTime, endTime);
            volumeReportRepository.GenerateReport(startTime, endTime, productLogs);
        }
    }
}