using iQuest.Business.Exceptions;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using iQuest.Business.UseCases;
using iQuest.Business.ViewInterfaces;
using Moq;
using Xunit;

namespace VendingMachineUnitTests.UseCaseTests.BuyUseCaseTests
{
    public class BuyUseExecuteTests
    {
        private Mock<IShelfColumnRepository> shelfColumnRepository;
        private Mock<ISalesHistoryRepository> logsRepository;
        private Mock<IBuyView> buyView;

        private Mock<IPayUseCase> payUseCase;
        private BuyUseCase buyUseCase;

        private ShelfColumn shelfColumn;

        public BuyUseExecuteTests()
        {
            shelfColumnRepository = new Mock<IShelfColumnRepository>();
            logsRepository = new Mock<ISalesHistoryRepository>();
            buyView = new Mock<IBuyView>();

            shelfColumn = new ShelfColumn
            {
                ColumnId = 3,
                Product = new Product { Name = "test", Price = 20, Quantity = 0 }
            };

            payUseCase = new Mock<IPayUseCase>();
            buyUseCase = new BuyUseCase(shelfColumnRepository.Object, logsRepository.Object, buyView.Object, payUseCase.Object);
        }

        [Fact]
        public void HavingAnEmptyStockShelfColumn_WhenExecuteIsCalled_ThenCheckIfExceptionThrown()
        {
            shelfColumn.Product.Quantity = 0;
            shelfColumnRepository.Setup(x => x.GetById(3)).Returns(shelfColumn);
            buyView.Setup(x => x.AskForColumnId()).Returns(3);

            Assert.Throws<InsufficientStockException>(() =>
            {
                buyUseCase.Execute();
            });
        }

        [Fact]
        public void HavingANonEmptyStockShelfColumn_WhenExecuteIsCalled_ThenCheckIfDispensed()
        {
            shelfColumn.Product.Quantity = 10;
            shelfColumnRepository.Setup(x => x.GetById(3)).Returns(shelfColumn);
            buyView.Setup(x => x.AskForColumnId()).Returns(3);

            buyUseCase.Execute();

            buyView.Verify(x => x.DispenseProduct(shelfColumn.Product.Name), Times.Once);
        }
    }
}