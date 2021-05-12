using Business.ViewInterfaces;
using iQuest.Business.Models;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using iQuest.Business.UseCases.ReportUseCases;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachineUnitTests.ReportsTests
{
    public class SalesReportUseCaseTests
    {
        private readonly Mock<ISalesHistoryRepository> logsRepository;
        private readonly Mock<ISalesReportRepository> salesReportRepository;
        private readonly Mock<IReportView> reportView;

        private readonly SalesReportUseCase useCase;

        public SalesReportUseCaseTests()
        {
            logsRepository = new Mock<ISalesHistoryRepository>();
            salesReportRepository = new Mock<ISalesReportRepository>();
            reportView = new Mock<IReportView>();

            useCase = new SalesReportUseCase(logsRepository.Object, salesReportRepository.Object, reportView.Object);
        }

        [Fact]
        public void HavingASalesReportUseCase_WhenExecuteIsCalled_ThenRepositoryGenerateReportIsCalled()
        {
            Tuple<DateTime, DateTime> dateRange = new Tuple<DateTime, DateTime>(DateTime.Today, DateTime.Today.AddDays(1));
            List<Sale> list = new List<Sale>();
            logsRepository.Setup(x => x.GetInDateRange(dateRange.Item1, dateRange.Item2)).Returns(list);
            reportView.Setup(x => x.AskDateTimes()).Returns(dateRange);

            useCase.Execute();

            salesReportRepository.Verify(x => x.GenerateReport(list), Times.Once);
        }
    }
}