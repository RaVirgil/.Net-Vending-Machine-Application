using iQuest.Business.Authentication;
using Moq;
using Presentation.Commands;
using Presentation.Factories;
using Xunit;

namespace VendingMachineUnitTests.CommandsTests.BuyCommandTests
{
    public class BuyCommandConstructorTests
    {
        private Mock<IUseCaseFactory> useCaseFactory;
        private Mock<IAuthenticationService> authenticationService;
        private BuyCommand buyCommand;

        public BuyCommandConstructorTests()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
            authenticationService = new Mock<IAuthenticationService>();
            buyCommand = new BuyCommand(useCaseFactory.Object, authenticationService.Object);
        }

        [Fact]
        public void WhenInstantiatingABuyUseCase_ThenCheckNameProperty()
        {
            Assert.Equal("buy", buyCommand.Name);
        }

        [Fact]
        public void WhenInstantiatingABuyUseCase_ThenCheckDescriptionProperties()
        {
            Assert.Equal("buy a product from the shelf", buyCommand.Description);
        }

        [Fact]
        public void HavingUnauthenticatedUser_WhenInstantiatingABuyUseCase_ThenCheckCanExecuteIsTrue()
        {
            authenticationService
                .SetupGet(x => x.IsUserAuthenticated)
                .Returns(false);

            Assert.True(buyCommand.CanExecute);
        }

        [Fact]
        public void HavingAuthenticatedUser_WhenInstantiatingABuyUseCase_ThenCheckCanExecuteIsFalse()
        {
            authenticationService
                .SetupGet(x => x.IsUserAuthenticated)
                .Returns(true);

            Assert.False(buyCommand.CanExecute);
        }
    }
}