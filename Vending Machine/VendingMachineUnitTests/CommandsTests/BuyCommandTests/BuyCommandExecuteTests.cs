using iQuest.Business.Authentication;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using iQuest.Business.UseCases;
using iQuest.Business.ViewInterfaces;
using Moq;
using Presentation.Commands;
using Presentation.Factories;
using Xunit;

namespace VendingMachineUnitTests.CommandsTests.BuyCommandTests
{
    public class BuyCommandExecuteTests
    {
        private Mock<IUseCaseFactory> useCaseFactory;
        private Mock<IAuthenticationService> authenticationService;
        private BuyCommand buyCommand;

        public BuyCommandExecuteTests()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
            authenticationService = new Mock<IAuthenticationService>();
            buyCommand = new BuyCommand(useCaseFactory.Object, authenticationService.Object);
        }

        [Fact]
        public void HavingABuyCommand_WhenExecuteIsCalled_ThenFactoryReturnsBuyUseCase()
        {
            useCaseFactory
                .Setup(x => x.GetUseCase<BuyUseCase>())
                .Returns(CreateBuyUseCase());

            buyCommand.Execute();

            useCaseFactory.Verify(x => x.GetUseCase<BuyUseCase>(), Times.Once);
        }

        private BuyUseCase CreateBuyUseCase()
        {
            Mock<IShelfColumnRepository> shelfColumnRepository = new Mock<IShelfColumnRepository>();
            Mock<ISalesHistoryRepository> logsRepository = new Mock<ISalesHistoryRepository>();
            Mock<IBuyView> buyView = new Mock<IBuyView>();
            Mock<IPayUseCase> payUseCase = new Mock<IPayUseCase>();
            ShelfColumn shelfColumn = new ShelfColumn
            {
                ColumnId = 3,
                Product = new Product { Name = "test", Price = 20, Quantity = 1 }
            };
            shelfColumnRepository
                .Setup(x => x.GetById(3))
                .Returns(shelfColumn);
            buyView
                .Setup(x => x.AskForColumnId())
                .Returns(3);

            return new BuyUseCase(shelfColumnRepository.Object, logsRepository.Object, buyView.Object, payUseCase.Object);
        }
    }
}