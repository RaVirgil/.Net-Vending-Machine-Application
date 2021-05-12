using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    public class BuyCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "buy";
        public string Description => "buy a product from the shelf";
        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<BuyUseCase>();
            useCase.Execute();
        }
    }
}