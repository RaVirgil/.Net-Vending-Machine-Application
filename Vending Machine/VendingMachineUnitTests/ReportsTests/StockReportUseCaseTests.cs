using iQuest.Business.Models;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using iQuest.Business.UseCases.ReportUseCases;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace VendingMachineUnitTests.ReportsTests
{
    public class StockReportUseCaseTests
    {
        private readonly Mock<IShelfColumnRepository> shelfColumnRepository;
        private readonly Mock<IStockReportRepository> stockReportRepository;

        private readonly StockReportUseCase useCase;

        public StockReportUseCaseTests()
        {
            shelfColumnRepository = new Mock<IShelfColumnRepository>();
            stockReportRepository = new Mock<IStockReportRepository>();

            useCase = new StockReportUseCase(shelfColumnRepository.Object, stockReportRepository.Object);
        }

        [Fact]
        public void HavingAStockReportUseCase_WhenExecuteIsCalled_ThenRepositoryGenerateReportIsCalled()
        {
            List<ShelfColumn> list = new List<ShelfColumn>();
            shelfColumnRepository.Setup(x => x.GetAll()).Returns(list);

            useCase.Execute();

            stockReportRepository.Verify(x => x.GenerateReport(list), Times.Once);
        }
    }
}