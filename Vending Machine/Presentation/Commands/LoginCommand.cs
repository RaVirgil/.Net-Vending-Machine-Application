using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    public class LoginCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "login";
        public string Description => "admin login";
        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<LoginUseCase>();
            useCase.Execute();
        }
    }
}