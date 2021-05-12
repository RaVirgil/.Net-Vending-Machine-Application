using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    public class LogoutCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "logout";
        public string Description => "logout from admin account";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<LogoutUseCase>();
            useCase.Execute();
        }
    }
}