using iQuest.Business.Models;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using System;
using System.Collections.Generic;

namespace iQuest.Business.UseCases.ReportUseCases
{
    public class StockReportUseCase : IUseCase
    {
        private readonly IShelfColumnRepository shelfColumnRepository;
        private readonly IStockReportRepository stockReportRepository;

        public StockReportUseCase(IShelfColumnRepository shelfColumnRepository, IStockReportRepository stockReportRepository)
        {
            this.shelfColumnRepository = shelfColumnRepository ?? throw new ArgumentNullException(nameof(shelfColumnRepository));
            this.stockReportRepository = stockReportRepository ?? throw new ArgumentNullException(nameof(stockReportRepository));
        }

        public void Execute()
        {
            List<ShelfColumn> shelfColumns = shelfColumnRepository.GetAll();
            stockReportRepository.GenerateReport(shelfColumns);
        }
    }
}